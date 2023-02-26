using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Tarea_CRUDTbUsuarios.Models
{
    [MetadataType(typeof(tbUsuariosMetaData))]
    public partial class tbUsuarios
    {
    }

    public class tbUsuariosMetaData
    {
        [Display(Name = "Usuario ID")]
        public int usu_Id { get; set; }



        [Display(Name = "Usuario Nombre")]
        [Required(ErrorMessage = "Este campo {0} es requerido.")]
        public string usu_Nambe { get; set; }


        [Display(Name = "Usuario Apellido")]
        [Required(ErrorMessage = "Este campo {0} es requerido.")]
        public string usu_Apellido { get; set; }


        [Display(Name = "Usuario Alias")]
        [Required(ErrorMessage = "Este campo {0} es requerido.")]
        public string usu_UsuarioAlias { get; set; }


        [Display(Name = "Usuario Contraseña")]
        [Required(ErrorMessage = "Este campo {0} es requerido.")]
        public string usu_Contra { get; set; }



        [Display(Name = "Es Administrador")]
        public bool usu_EsAdmin { get; set; }
    }
}