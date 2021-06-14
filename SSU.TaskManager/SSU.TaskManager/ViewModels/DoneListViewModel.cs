using System;
using System.Collections.Generic;
using System.Text;

namespace SSU.TaskManager.ViewModels
{
    public class DoneListViewModel
    {
        private DoneListViewModel()
        {
        }

        public string Name { private set; get; }

        private static string[] toDoitems = new string[] {};

        public static List<DoneListViewModel> All { private set; get; }

        // Static members.
        static DoneListViewModel()
        {
            List<DoneListViewModel> all = new List<DoneListViewModel>();

            // Loop through the public static fields of the Color structure.
            foreach (var name in toDoitems)
            {
                // Convert the name to a friendly name.

                var toDoItem = new DoneListViewModel
                {
                    Name = name,
                };

                // Add it to the collection.
                all.Add(toDoItem);
            }
            All = all;
        }
    }
}
