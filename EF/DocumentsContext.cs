using Meridian.Example.MVC.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Meridian.Example.MVC.EF
{
	public class DocumentsContext : DbContext
	{
		public DocumentsContext(DbContextOptions options) : base(options)
		{
		}

		public virtual DbSet<DocumentType> DocumentTypes { get; set; }
		public virtual DbSet<Site> Sites { get; set; }
	}

	//public class DocumentType
	//{
	//	public int Id { get; set; }
	//	public string Name { get; set; }
	//}

	
}
