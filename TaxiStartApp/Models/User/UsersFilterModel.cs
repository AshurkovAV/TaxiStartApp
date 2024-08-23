using FluentValidation;
using JobTaxi.Entity.Dto.User;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using TaxiStartApp.Models.Validators;


namespace TaxiStartApp.Models.User
{
    public class UsersFilterModel : UsersFilterDto,  IDataErrorInfo
    {
        private AbstractValidator<UsersFilterModel> _validator;
        public AbstractValidator<UsersFilterModel> Validator => _validator ?? (_validator = new UsersFilterValidator());

       


        #region IDataErrorInfo Members

        private bool _hasError;
        public bool HasError
        {
            get
            {
                return Validator != null
                    ? true
                    : false;
            }           
        }

        string IDataErrorInfo.Error
        {
            get
            {
                return Validator != null
                    ? string.Join(Environment.NewLine, Validator.Validate(this).Errors.Select(x => x.ErrorMessage).ToArray())
                    : string.Empty;
            }
        }

        string IDataErrorInfo.this[string propertyName]
        {
            get
            {
                if (Validator != null)
                {
                    var results = Validator.Validate(this);
                    if (results != null && results.Errors.Any())
                    {
                        var errors = string.Join(Environment.NewLine, results.Errors.Select(x => x.ErrorMessage).ToArray());
                        return errors;
                    }
                }
                return string.Empty;
            }
        }
        #endregion
    }
}
