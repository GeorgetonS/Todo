using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Todo.Domain.Entities;
using Todo.Domain.Queries;


namespace Todo.Domain.Tests.QueryTests
{
    [TestClass]
    public class TodoQueryTests
    {
        private List<TodoItem> _items;

        public TodoQueryTests()
        {
            _items = new List<TodoItem>();
            _items.Add(new TodoItem("Tarefa 1", "usuarioA", DateTime.Now));
            _items.Add(new TodoItem("Tarefa 2", "usuarioA", DateTime.Now));
            _items.Add(new TodoItem("Tarefa 3", "Jokerson", DateTime.Now));
            _items.Add(new TodoItem("Tarefa 4", "usuarioA", DateTime.Now));
            _items.Add(new TodoItem("Tarefa 5", "Jokerson", DateTime.Now));
        }

        [TestMethod]
        public void Dada_a_consulta_deve_retornar_tarefas_apenas_do_usuario_Jokerson()
        {
            var result = _items.AsQueryable().Where(TodoQueries.GetAll("Jokerson"));
            Assert.AreEqual(2, result.Count());
        }

        [TestMethod]
        public void deve_retornar_tarefas_apenas_do_usuario_usuarioA()
        {
            var result = _items.AsQueryable().Where(TodoQueries.GetAll("usuarioA"));
            Assert.AreEqual(3, result.Count());
        }


    }
}
