﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SESharp;
using SESharp.JSON;
using ServiceStack.Text;

namespace ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            StackExchange stackExchange = new StackExchange(@"%USERPROFILE%\secret.xml");

            Rate rate = stackExchange.Limit;
            
            Console.Out.WriteLine("Limit {0} of {1}", rate.Remaining, rate.Limit);

            Sites sites = stackExchange.Sites;
            Console.Out.WriteLine("{0} Sites:", sites.items.Count);

            foreach (Site site in sites.items)
            {
                Console.Out.Write("{0},", site.name);
            }

            Console.Out.WriteLine("\n\nRepository {0}:\n{1}", sites.items[0].name, sites.items[0].Dump());

            //Console.ReadKey();

            //Console.Out.WriteLine("\n\nRepository GET {0}:\n{1}", repos[0].Name, stackExchange.GetRepository(repos[0].Owner.Login, repos[0].Name).Dump());

            //Console.ReadKey();

            //List<Organization> orgs = stackExchange.MyOrganizations;
            //Console.Out.WriteLine("{0} Organizations:", orgs.Count);

            //foreach (Organization org in orgs)
            //{
            //    Console.Out.Write("{0},", org.Name);
            //}

            //Console.Out.WriteLine("\n\nOrganization {0}:\n{1}", orgs[0].Company, orgs[0].Dump());

            //Console.ReadKey();

            //Console.Out.WriteLine("\n\nOrganization GET {0}:\n{1}", orgs[0].Login, stackExchange.GetOrganization(orgs[0].Login).Dump());

            //Console.ReadKey();

            //List<Repository> orgRepos = stackExchange.GetRepositories(orgs[0].Login, UserType.Organization);
            //Console.Out.WriteLine("{0} Repositories:", orgRepos.Count);

            //foreach (Repository repo in orgRepos)
            //{
            //    Console.Out.Write("{0},", repo.Name);
            //}

            //Console.Out.WriteLine("\n\nRepository {0}:\n{1}", orgRepos[0].Name, orgRepos[0].Dump());

            //Console.ReadKey();

            //List<Gist> gists = stackExchange.MyGists;
            //Console.Out.WriteLine("{0} Gists:", gists.Count);

            //foreach (Gist gist in gists)
            //{
            //    Console.Out.Write("{0},", gist.Description);
            //}

            //Console.Out.WriteLine("\n\nGist {0}:\n{1}", gists[0].Description, gists[0].Dump());

            //Console.ReadKey();

            //Console.Out.WriteLine("\n\nGist GET {0}:\n{1}", gists[0].Description, stackExchange.GetGist(gists[0].Id).Dump());

            Console.ReadKey();
        }
    }
}
