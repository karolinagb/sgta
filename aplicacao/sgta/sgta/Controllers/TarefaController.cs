using sgta.Models;
using sgta.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace sgta.Controllers
{
    public class TarefaController : Controller
    {
        //Instanciando o arquivo TarefaRepositorio afim de usar os metodos da mesma
        private TarefaRepositorio _repositorio;

        //Metodo de envio na rota
        [HttpGet]
        //metodo do controle de acesso ao repositorio
        public ActionResult ObterTarefas()
        {
            //Instanciando a classe TarefaRepositorio
            _repositorio = new TarefaRepositorio();

            //Limpando todos os modelos
            ModelState.Clear();

            //Utilizando o metodo do repositorio e adicionando na view
            return View(_repositorio.ObterTarefas());
        }

        [HttpGet]
        public ActionResult Incluir()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Incluir(Tarefas tarefaObj)
        {
            try
            {
                //Verificando se os dados inseridos sao validos
                if (ModelState.IsValid)
                {
                    _repositorio = new TarefaRepositorio();

                    if (_repositorio.CadastrarTarefa(tarefaObj))
                    {
                        ViewBag.Mensagem = "Tarefa cadastrado com sucesso";
                    }
                }
                return View();
            }
            catch (Exception)
            {
                return View("ObterTarefas");
            }
        }

        [HttpGet]
        public ActionResult EditarTarefa(int id)
        {
            _repositorio = new TarefaRepositorio();

            //Retornando uma view  com todos os atributos da tarefa do id selecionado atraves da função Find
            return View(_repositorio.ObterTarefas().Find(t => t.id == id));
        }

        [HttpPost]
        public ActionResult EditarTarefa(int id, Tarefas tarefaObj)
        {
            try
            {
                _repositorio = new TarefaRepositorio();
                _repositorio.AtualizarTarefa(tarefaObj);
                return RedirectToAction("ObterTarefas");
            }
            catch (Exception)
            {
                return View("ObterTarefas");
            }
        }

        public ActionResult Excluir (int id)
        {
            try
            {
                _repositorio = new TarefaRepositorio();
                if (_repositorio.ExcluirTarefa(id))
                {
                    ViewBag.Mensagem = "Tarefa excluída com sucesso";
                }

                return RedirectToAction("ObterTarefas");
            }
            catch (Exception)
            {
                return View("ObterTarefas");
            }
        }

        public ActionResult ObterTarefasPorData()
        {
            //variavel para pegar data do sistema atravs da funçao DateTime.Now.ToString("yyyy-MM-dd")
            string data = DateTime.Now.ToString("yyyy-MM-dd");
            
            //Instanciando a classe TarefaRepositorio
            _repositorio = new TarefaRepositorio();

            //Limpando todos os modelos
            ModelState.Clear();

            //Utilizando o metodo do repositorio e adicionando na view
            return View(_repositorio.ObterTarefasPorData(data));
        }
    }
}