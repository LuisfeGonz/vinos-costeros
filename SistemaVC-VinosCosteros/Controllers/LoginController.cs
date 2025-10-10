using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using SistemaVC_VinosCosteros.Models;

namespace SistemaVC_VinosCosteros.Controllers
{
    public class LoginController : Controller
    {
        private VinosCosterosEntities db = new VinosCosterosEntities();

        // GET: Login
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(FormCollection form)
        {
            string email = form["Email"];
            string password = form["Password"];
            bool rememberMe = form["RememberMe"] == "true";

            if (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(password))
            {
                try
                {
                    // Buscar usuario por email y contraseña
                    var usuario = db.usuarios.FirstOrDefault(u =>
                        u.email == email &&
                        u.contrasenia == password &&
                        u.estatus == "1");

                    if (usuario != null)
                    {
                        // Crear ticket de autenticación
                        FormsAuthentication.SetAuthCookie(usuario.email, rememberMe);

                        // Guardar información del usuario en sesión
                        Session["UsuarioId"] = usuario.id;
                        Session["UsuarioNombre"] = $"{usuario.nombre} {usuario.apellido}";
                        Session["UsuarioRol"] = usuario.rol?.nombre ?? "Usuario";
                        Session["UsuarioRolId"] = usuario.idRol;

                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ViewBag.Error = "Email o contraseña incorrectos, o usuario inactivo.";
                    }
                }
                catch (Exception ex)
                {
                    ViewBag.Error = "Error al iniciar sesión: " + ex.Message;
                }
            }
            else
            {
                ViewBag.Error = "Email y contraseña son requeridos.";
            }

            return View();
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult AccessDenied()
        {
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}