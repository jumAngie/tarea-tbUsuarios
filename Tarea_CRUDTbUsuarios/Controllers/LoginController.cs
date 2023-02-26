using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tarea_CRUDTbUsuarios.Models;
using System.Data.Entity;

namespace Tarea_CRUDTbUsuarios.Controllers
{
	public class LoginController : Controller
	{
		private DB_USUARIOSEntities db = new DB_USUARIOSEntities();
		// GET: Login
		public ActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Index(string txtUsuario, string txtContraseña)
		{
			if (txtUsuario == "" && txtContraseña == "")
			{
				ModelState.AddModelError("Validador", "El Usuario/Contraseña son requeridos");
				return View();
			}
			else
			{
				var Login = db.UDP_VALIDAR_LOGIN(txtUsuario, txtContraseña).ToList();

				if (Login.Count() > 0)
				{
					foreach (var item in Login)
					{
						Session["Usuario"] = item.usu_Id;
						Session["Alias"] = item.usu_UsuarioAlias;
						return RedirectToAction("Principal");
					}

				}
				else
				{
					ModelState.AddModelError("Validador", "El Usuario/Contraseña son incorrectos");
					return View();
				}
				return RedirectToAction("Principal");
			}

		}

		public ActionResult Principal()
		{
			return View();
		}
	}

}