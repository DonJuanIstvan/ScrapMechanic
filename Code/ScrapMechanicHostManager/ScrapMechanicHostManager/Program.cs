using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GitSharp;
using GitSharp.Commands;

namespace ScrapMechanicHostManager
{
    class Program
    {
        static void Main(string[] args)
        {
            //Opening an existing git repository
            if (Directory.Exists(@"C:/Git"))
            {
                Directory.Delete(@"C:/Git", true);
            }
            Git.Clone(@"git://github.com/DonJuanIstvan/ScrapMechanic", @"C:/Git");

            Repository repo = new Repository(@"C:\Git");

            // Now suppose you have created some new files and want to commit them
            //if(File.Exists(@"C:\Git\ScrapMechanic\LM.db"))
            //{
            //    File.Delete(@"C:\Git\ScrapMechanic\LM.db");
            //}
            //File.Copy(@"C:\Users\linus\AppData\Roaming\Axolot Games\Scrap Mechanic\User\User_76561198199571049\Save\Survival\LM.db", @"H:\Git\ScrapMechanic\LM.db");
            repo.Index.Add(@"\ScrapMechanic\LM.db");
            Commit commit = repo.Commit("My first commit with gitsharp", new Author("henon", "meinrad.recheis@gmail.com"));

            // Easy, isn't it? Now let's have a look at the changes of this commit:
            foreach (Change change in commit.Changes)
                Console.WriteLine(change.Name + " " + change.ChangeType);

            //Get the staged changes from the index
            repo.Status.Added.Contains("README");

            //Access and manipulate the configuration
            repo.Config["core.autocrlf"] = "false";
        }
    }
}
