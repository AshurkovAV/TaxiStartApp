using Android.Content.OM;
using Autofac;
using Core.Attributes;
using Core.Infrastructure;
using Core.Services;
using System.Reflection;


namespace TaxiStartApp.Internal
{
    public class Bootstrapper
    {
        //Имплементация паттерна одиночка (Singlton)
        #region Singlton
        private static volatile Bootstrapper _instance;
        private static readonly object SyncRoot = new Object();

        public static Bootstrapper Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (SyncRoot)
                    {
                        if (_instance == null)
                            _instance = new Bootstrapper();
                    }
                }
                return _instance;
            }
        }
        #endregion

        /// <summary>
        /// Список сборок приложения
        /// </summary>
        private readonly List<String> _moduleAssemblies = new List<String>
                                                        {
                                                            "Core" ,
                                                            "DataCore"
                                                        };

        //Инициализация загрузчика
        public bool Init()
        {   
            LoadModules();
            InitInjections();
            return LastError == null;
        }
        public Exception LastError { get; protected set; }
        /// <summary>
        /// Инициализация контейнера IoC
        /// </summary>
        private void InitInjections()
        {
            var builder = new ContainerBuilder();

            Di.Update(builder);
        }

        //Загрузка модулей приложения
        private void LoadModules()
        {
            try
            {
                //Загрузка сборок приложения
                _moduleAssemblies.ForEach(p =>
                {   
                    Assembly.Load(p);
                });
            }
            catch (Exception exception)
            {
                
            }

            try
            {
                //Получение атрибутов загруженных модулей приложения
                var results = AppDomain.CurrentDomain.GetAssemblies()
                    .Select(p => new { p.GetName().Name, Data = p })
                    .Where(p => _moduleAssemblies.Contains(p.Name))
                    .Select(p => p.Data)
                    .Select(p => p.GetTypes())
                    .SelectMany(p => p)
                    .Select(GetModuleAttribute)
                    .SelectMany(r => r)
                    .ToList();

                //Инициализация модулей с помощью метода с атрибутом ModuleAttribute
                foreach (var type in results)
                {
                    var commandClass = (IModuleActivator)Activator.CreateInstance(type.ClassType);
                    if (commandClass != null)
                    {
                        commandClass.Run();
                    }
                }
            }
            catch (Exception exception)        {
               
            }
        }

        internal IEnumerable<ModuleAttribute> GetModuleAttribute(Type type)
        {
            Attribute[] attrs = Attribute.GetCustomAttributes(type);
            return attrs.OfType<ModuleAttribute>().ToList();
        }
    }

}
