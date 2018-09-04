using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Web;

namespace Rifa.WEB.Validations
{
    //Regra 1) Herdar ValidationAttibute..
    public class UploadFotoValidation: ValidationAttribute
    {
            //Regra 2) Sobrescrever o método IsValid
            public override bool IsValid(object value)
            {
                //verificar o tipo do valor recebido..
                if (value is HttpPostedFileBase)
                {
                    //converter..
                    HttpPostedFileBase arquivo = value as HttpPostedFileBase;

                    //verificar se o tipo do arquivo é JPG ou PNG
                    string tipo = Path.GetExtension(arquivo.FileName).ToLower();

                    //validando as extensões permitidas..
                    return tipo.Contains("jpg")
                        || tipo.Contains("jpeg")
                        || tipo.Contains("png");
                }

                return false;
            }
    }
}