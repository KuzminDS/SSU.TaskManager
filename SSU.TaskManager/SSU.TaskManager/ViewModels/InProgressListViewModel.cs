using System;
using System.Collections.Generic;
using System.Text;

namespace SSU.TaskManager.ViewModels
{
    public class InProgressListViewModel
    {
        private InProgressListViewModel()
        {
        }

        public string Name { private set; get; }

        private static string[] toDoitems = new string[] { };

        public static List<InProgressListViewModel> All { private set; get; }

        // Static members.
        static InProgressListViewModel()
        {
            List<InProgressListViewModel> all = new List<InProgressListViewModel>();

            // Loop through the public static fields of the Color structure.
            foreach (var name in toDoitems)
            {
                // Convert the name to a friendly name.

                var toDoItem = new InProgressListViewModel
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
