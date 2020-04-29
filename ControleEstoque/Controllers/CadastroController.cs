

using ControleEstoque.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControleEstoque.Web.Controllers {
    public class CadastroController : Controller {

        [Authorize]
        public ActionResult GrupoProduto() {
            return View(GrupoProdutoModel.RecuperarLista());
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult RecuperarGrupoProduto(int id) {
            return Json(GrupoProdutoModel.RecuperarPeloId(id));
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult ExcluirGrupoProduto(int id) {
            return Json(GrupoProdutoModel.ExcluirPeloId(id));
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult SalvarGrupoProduto(GrupoProdutoModel model) {

            var resultado = "OK";
            var mensagens = new List<String>();
            var idSalvo = string.Empty;

            if (!ModelState.IsValid) 
            {
                resultado = "AVISO";
                mensagens = ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList();

            } else {
                try {
                    var id = model.Salvar();
                    if (id > 0) {
                        idSalvo = id.ToString();
                    } else {
                        resultado = "ERRO";
                    }
                } catch (Exception) {

                    resultado = "ERRO";

                } 
            }
            return Json(new {Resultado = resultado, Mensagens = mensagens, IdSalvo = idSalvo }); 
         }

        [Authorize]
        public ActionResult MarcaProduto() {
            return View();
        }

        [Authorize]
        public ActionResult LocalProduto() {
            return View();
        }

        [Authorize]
        public ActionResult UnidadeMedida() {
            return View();
        }

        [Authorize]
        public ActionResult Produto() {
            return View();
        }

        [Authorize]
        public ActionResult Pais() {
            return View();
        }

        [Authorize]
        public ActionResult Estado() {
            return View();
        }

        [Authorize]
        public ActionResult Cidade() {
            return View();
        }

        [Authorize]
        public ActionResult Fornecedor() {
            return View();
        }

        [Authorize]
        public ActionResult PerfilUsuario() {
            return View();
        }

        [Authorize]
        public ActionResult Usuario() {
            return View();
        }
    }
}





















//using ControleEstoque.Models;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;

//namespace ControleEstoque.Controllers {

//    public class CadastroController : Controller {


//        [Authorize]
//        public ActionResult Cadastro() {
//            return View();
//        }
//        [Authorize]
//        public ActionResult Usuario() {
//            return View();
//        }
//        private static List<GrupoProduto> _listaGrupoProduto = new List<GrupoProduto>() {

//            new GrupoProduto() {  Id=1,  Nome="Livros", Ativo=true },
//            new GrupoProduto() {  Id=2,  Nome="Mouses", Ativo=true },
//            new GrupoProduto() { Id = 3,  Nome = "Monitores", Ativo = false } 
//        };


//        [Authorize]
//        public ActionResult Produto() {
//            return View(_listaGrupoProduto);
//        }

//        [HttpPost]
//        [Authorize]
//        public ActionResult RecuperarGrupoProduto(int id) {

//            return Json(_listaGrupoProduto.Find(x => x.Id == id));
//        }

//        [HttpPost]
//        [Authorize]
//        public ActionResult ExcluirGrupoProduto(int id) {

//            var ret = false;

//            var registroBD = _listaGrupoProduto.Find(x => x.Id == id);
//            if (registroBD != null) {
//                _listaGrupoProduto.Remove(registroBD);
//                ret = true;
//            }

//            return Json(ret);
//        }

//        [HttpPost]
//        [Authorize]
//        public ActionResult SalvarGrupoProduto(GrupoProduto model) {

//            var registroBD = _listaGrupoProduto.Find(x => x.Id == model.Id);

//            if (registroBD == null) {
//                registroBD = model;
//                registroBD.Id = _listaGrupoProduto.Max(x => x.Id) + 1;
//                _listaGrupoProduto.Add(registroBD);
//            } else {
//                registroBD.Nome = model.Nome;
//                registroBD.Ativo = model.Ativo;
//            }

//            return Json(registroBD);
//        }
//    }
//}