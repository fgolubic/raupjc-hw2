using System;
using System.Collections.Generic;
using System.Linq;
using _3rd_Assigment;

namespace Todo
{
    /// <summary >
    /// Class that encapsulates all the logic for accessing TodoTtems .
    /// </summary >
    public class TodoRepository : ITodoRepository
    {
        /// <summary >
        /// Repository does not fetch todoItems from the actual database ,
        /// it uses in memory storage for this excersise .
        /// </summary >
        private readonly IGenericList<TodoItem> _inMemoryTodoDatabase;


        public TodoRepository(IGenericList<TodoItem> initialDbState = null)
        {
            _inMemoryTodoDatabase = initialDbState ?? new GenericList<TodoItem>();

            // Shorter way to write this in C# using ?? operator :
            // x ?? y = > if x is not null , expression returns x. Else it will return y.
            // _inMemoryTodoDatabase = initialDbState ?? new List < TodoItem >();
        }

        public TodoItem Get(Guid todoId)
        {
            return _inMemoryTodoDatabase.FirstOrDefault(i => i.Id== todoId);
        }

        public TodoItem Add(TodoItem todoItem)
        {
            if (_inMemoryTodoDatabase.FirstOrDefault(i => i.Id.Equals(todoItem.Id)) != null)
            {
                throw new DuplicateTodoItemException("duplicate id: " + todoItem.Id.ToString());
            }
            _inMemoryTodoDatabase.Add(todoItem);
            return todoItem;
        }

        public bool Remove(Guid todoId)
        {
            if (_inMemoryTodoDatabase.FirstOrDefault(i => i.Id.Equals(todoId)) != null)
            {
                TodoItem item = _inMemoryTodoDatabase.FirstOrDefault(i => i.Id.Equals(todoId));

                _inMemoryTodoDatabase.Remove(item);

                return true;
            }

            return false;
        }

        public TodoItem Update(TodoItem todoItem)
        {
            if (!_inMemoryTodoDatabase.Contains(todoItem))
            {
                _inMemoryTodoDatabase.Add(todoItem);

                return todoItem;
            }

            else
            {
                _inMemoryTodoDatabase.Remove(_inMemoryTodoDatabase.
                    FirstOrDefault(i => i.Id.Equals(todoItem.Id)));


                _inMemoryTodoDatabase.Add(todoItem);
                return todoItem;
            }

        }

        public bool MarkAsCompleted(Guid todoId)
        {
            TodoItem item = _inMemoryTodoDatabase.FirstOrDefault(i => i.Id.Equals(todoId));

            if (item == null)
            {
                return false;
            }

            if (item.IsCompleted) return false;

            item.MarkAsCompleted();

            if(this.Update(item)==null) return false;

            return true;
        }

        public List<TodoItem> GetAll()
        {
            return _inMemoryTodoDatabase.OrderByDescending(i => i.DateCreated).ToList();
        }

        public List<TodoItem> GetActive()
        {
            return _inMemoryTodoDatabase.Where(i=> i.IsCompleted == false ).ToList();
        }

        public List<TodoItem> GetCompleted()
        {
            return _inMemoryTodoDatabase.Where(i => i.IsCompleted == true).ToList();
        }

        public List<TodoItem> GetFiltered(Func<TodoItem, bool> filterFunction)
        {
            return _inMemoryTodoDatabase.Where(filterFunction).ToList();
        }
    }
}