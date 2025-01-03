using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using trilha_net_desafio_mvc.Context;
using trilha_net_desafio_mvc.Models;

namespace trilha_net_desafio_mvc.Controllers
{
    public class TarefaController:Controller
    {
        private readonly TarefaContext _context;
        public TarefaController(TarefaContext context)
        {
            _context = context;    
        }

        public IActionResult Index(){
            var tarefa = _context.Tarefas.ToList();
            return View(tarefa);
        }

        public IActionResult Criar(){
            return View();
        }

        [HttpPost]
        public IActionResult Criar(Tarefa tarefa){
            if(ModelState.IsValid){
                _context.Tarefas.Add(tarefa);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tarefa);
        }

        public IActionResult Editar(int id){
            var tarefa = _context.Tarefas.Find(id);
            if(tarefa == null){
                return RedirectToAction(nameof(Index));
            }
            return View(tarefa);
        }

        [HttpPost]
        public IActionResult Editar(Tarefa tarefa){
            var tarefaBanco = _context.Tarefas.Find(tarefa.Id);
            if(tarefaBanco == null){
                return RedirectToAction(nameof(Index));
            }
            tarefaBanco.Titulo = tarefa.Titulo;
            tarefaBanco.Descricao = tarefa.Descricao;
            tarefaBanco.Data = tarefa.Data;
            tarefaBanco.Status = tarefa.Status;
            _context.Tarefas.Update(tarefaBanco);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Detalhes(int id){
            var tarefa = _context.Tarefas.Find(id);
            if(tarefa == null){
                return RedirectToAction(nameof(Index));
            }
            return View(tarefa);
        }

          public IActionResult Deletar(int id){
            var tarefa = _context.Tarefas.Find(id);
            if(tarefa == null){
                return RedirectToAction(nameof(Index));
            }
            return View(tarefa);
        }

        [HttpPost]
        public IActionResult Deletar(Tarefa tarefa){
            var tarefaBanco = _context.Tarefas.Find(tarefa.Id);
            if(tarefaBanco == null){
                return RedirectToAction(nameof(Index));
            }
            _context.Tarefas.Remove(tarefaBanco);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        
    }
}