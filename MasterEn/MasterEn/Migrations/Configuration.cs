using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Security.Policy;
using System.Web.Hosting;
using MasterEn.Classes;
using MasterEn.Models;
using System.Web;
using System.Data.Entity.Migrations;
using System.Linq;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MasterEn.Migrations
{
	internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
	{
		public Configuration()
		{
			AutomaticMigrationsEnabled = true;
			ContextKey = "MasterEn.Models.ApplicationDbContext";
		}

		private static string MapPath(string seedFile)
		{
			var path = (@"C:\Users\zamap\Documents\Visual%20Studio%202013\Projects\MasterEn\MasterEn\" + seedFile);
			return Uri.UnescapeDataString(path);
		}
		protected override void Seed(ApplicationDbContext context)
		{
			//  You can use the DbSet<T>.AddOrUpdate() helper extension method 
			//sqllocaldb.exe stop v11.0
			//sqllocaldb.exe delete v11.0
			//Now execute "update-database" 

			var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
			var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

			const string name = "Admin";
			const string password = "123456";

			//Create Role Admin if it does not exist
			if (!roleManager.RoleExists(name))
			{
				var roleresult = roleManager.Create(new IdentityRole(name));
			}

			//Create User=Admin with password=123456
			var user = new ApplicationUser {UserName = name};
			var adminresult = userManager.Create(user, password);

			//Add User Admin to Role Admin
			if (adminresult.Succeeded)
			{
				var result = userManager.AddToRole(user.Id, name);
			}
			base.Seed(context);

			if (context.CatalogItemModels.Any()) return;

			var item0 = new CatalogItemModel()
						{
							Name = "��������� ����� (WinFun)",
							ShortDescription = "������������� ��������� ����� ������� ������ ������� ������� ����� ��������, �����, ������� �������� �����, � ����� 26 ���������� ����.",
							Image = ImageHelper.ImageToByteArray(System.Drawing.Image.FromFile(MapPath(@"Content\Images\Shop\TalkingAlphabetPlayer.jpg"), true)),
							Price = 989,
							Age = 5,
							ProductCount = 1,
							Size = "34x34",
							Description = "<h4>5 ������� ������:</h4><ol><li><b>��������� 1.</b> �������, ��� ������������ ���������� �����, � ����� ����� ���������� ������ ����� � ����� ���� �������� ������ �����.</li><li><b>��������� 2.</b> ��������� ����������� ����� �� ������. ���� ����� ������� ��������� ���������� �����, � ����� ��������� ����.</li><li><b>����������� 1</b> (����� ����� ������� �� ������ U?)</li><li><b>����������� 2</b> (� ����� ����� ���������� ����� Leg?)</li><li><b>�����������</b></li></ol><p>��������� ������� �����, ����� ������ ����� � ����� � ������. ��������� ����� �������� �� 2 �������� �� (������ � ��������).</p>",
							Video = "<iframe width=\"100%\" height=\"auto\" src=\"//www.youtube.com/embed/NkK0Dryk1Js\" frameborder=\"0\" allowfullscreen></iframe>"
						};
			var item1 = new CatalogItemModel
						{
							Name = "������� ���� (LeapFrog)",
							ShortDescription = "'������� ����' ������� ������ ������� ������� ���������� �������.",
							Image = ImageHelper.ImageToByteArray(System.Drawing.Image.FromFile(MapPath(@"Content\Images\Shop\LetterFactory.jpg"), true)),
							Price = 969,
							Age = 3,
							ProductCount = 1,
							Size = "34x34",
							Description = "<p>� �������� ������ 26 �������� ���� � \"�������\", � ������� ������� ����� \"�������\" - �� ������� �������� �����, ����� ���� ��� ��������. � ��� ������� ����������� - ������� ������� ��� ������ �����!</p><p>\"������� ����\" �������� �� 3 �������� ���.</p>",
							Video = "<iframe width=\"100%\" height=\"auto\" src=\"//www.youtube.com/embed/FR3jsROCYQ0\" frameborder=\"0\" allowfullscreen></iframe>"
						};
			var item2 = new CatalogItemModel
						{
							Name = "�������� ���� (LeapFrog)",
							ShortDescription = "��� ������������� ������� ������� ������ ������� ��������� ���������� �����, � ����� ��������� �� ������.",
							Image = ImageHelper.ImageToByteArray(System.Drawing.Image.FromFile(MapPath(@"Content\Images\Shop\Count&Draw.jpg"), true)),
							Price = 979,
							Age = 5,
							ProductCount = 1,
							Size = "34x34",
							Description = "<h4>3 ������ ������:</h4><ol><li><b>�������� ��������� ����.</b> ������������ ����� �� ������ ������� ��������� ������ ����� (������, ���������), ������, ����������� � ��. ��������.</li><li><b>�������� ������ (�����).</b> ������������ ����� �� ������ ���������, ��� ��������� �������� ������ �����.</li><li><b>�������� �����.</b> ����������� ���������� ������������ ����� �� ������.</li></ol><p>��� ������ ���� �� ������ ������������ ������, ������� ���������� ���������� ��� ��������� ���� �������.</p><p>����� ������� ������������ ������� �� �������� ������ ����� ������.<p><p>�������� �������� �� ���� �������� �� (������ � ��������).</p>",
							Video = "<iframe width=\"100%\" height=\"auto\" src=\"//www.youtube.com/embed/t9hyJPFgIws\" frameborder=\"0\" allowfullscreen></iframe>"
						};
			var item4 = new CatalogItemModel
						{
							Name = "������������� ����� \"��������� ���������\" (VTech)",
							ShortDescription = "������������� ����� \"��������� ���������\" ������� ������ ������� ������� ����� ����������� ��������, 26 ����� ����, �������������� ����� � �����.",
							Image = ImageHelper.ImageToByteArray(System.Drawing.Image.FromFile(MapPath(@"Content\Images\Shop\Touch&Teach%20Turtle.jpg"), true)),
							Price = 899,
							Age = 5,
							ProductCount = 1,
							Size = "34x34",
							Description = "<h4>3 ������ ������:</h4><ol><li><b>����� ����</b><br/>���������� �������� ���� � �����, ��������������� ������ ����� ��������</li><li><b>����� \"�������� ������\"</b><br />��������� ��������� ��� ����� � ����� � ������� ��� ����� ��������</li><li><b>����������� �����</b><br />��������� ��� ����� � ����� ��� ������� �������</li></ol><p>16 �������, ��������� ������ � �������������� ������ (����, �������, ����������� � �.�.)</p><p>������������ ���������� ������ ������ ������� �������� ����� �������������.</p><p>8  ������ �� ������ ��������� ������  ������ (�� 1 �� 8) � ������.</p><p>������������ ���������� ������ ������ ������� �������� ����� �������������.</p><p>��������� ������� �����, ����� ������ ����� � ����� � ������.</p><p>������������� ��������� �������� �� 2 �������� �� (������ � ��������).</p>",
							Video = "<iframe width=\"100%\" height=\"auto\" src=\"//www.youtube.com/embed/9fcNTtRTFWU\" frameborder=\"0\" allowfullscreen></iframe>"
						};

			var item5 = new CatalogItemModel
						{
							Name = "������������� �������� (VTech)",
							ShortDescription = "������������� �������� ������� ������ ������� ��������� 100 ���� �� 6 ��������� (��������, �������� � �.�.).",
							Image = ImageHelper.ImageToByteArray(System.Drawing.Image.FromFile(MapPath(@"Content\Images\Shop\Touch&TeachWordBook1.jpg"), true)),
							Price = 1199,
							Age = 7,
							ProductCount = 1,
							Size = "34x34",
							Description = "<h4>4 ������ ������:</h4><ol><li><b>��������� 1</b><br>��� ���? ������������� � ��������, �� �������� �������� �������� � ��� ����������� ����</li><li><b>��������� 2</b><br>������� �����. �������, � ����� ����� ���������� ������ �����.</li><li><b>����������� �����</b></li><li><b>�����������</b></li><p>���������. ����������� �������� ��������  � ������� ��������������� ��������.</p></ol><p>12 �������, ����� 100 ���� �� 6 ��������� ���������: ���, ��������, ������, ��������, ������� � ������� ��������. �� ��������� ����� ��� ����� ������������ ������� ��������� - ����� ���� � ����.��������� ������ ��������� ����� ����� � ����� � ������. ������������� �������� �������� �� ���� �������� ��� (������ � ��������).</p>",
							Video = "<iframe width=\"100%\" height=\"auto\" src=\"//www.youtube.com/embed/YK4zs2YAxVo\" frameborder=\"0\" allowfullscreen></iframe>"
						};

			var item6 = new CatalogItemModel
						{
							Name = "��������� ������� (LeapFrog)",
							ShortDescription = "������������� \"��������� �������\" ������� ������ ������� ������� ���������� ������� � 26 ����� ����, ��������������� ������ �����.",
							Image = ImageHelper.ImageToByteArray(System.Drawing.Image.FromFile(MapPath(@"Content\Images\Shop\TouchMagicLearningBus.jpg"), true)),
							Price = 989,
							Age = 5,
							ProductCount = 1,
							Size = "34x34",
							Description = "<h4>3 ������ ������:</h4><ol><li><b>���������</b><br />�����, ��� ���������� ����� ����������� ��������, ����� ����� ��� �������� � ����� ����� �� ������ �����. ��� ����� �������������� ��������� �������, ������� ������ �������� � ��������.</li><li><b>�����������</b><br />���������. (����� ����� �. ����� ������� ������ ���� ����?)<li><b>�����������</b></li></ol><p>������������� ������� �������� �� 3 �������� ��� (������ � ��������).</p>",
							Video = "<iframe width=\"100%\" height=\"auto\" src=\"//www.youtube.com/embed/dLjXsctwJi0\" frameborder=\"0\" allowfullscreen></iframe>"
						};
			var item7 = new CatalogItemModel
						{
							Name = "������������� ����-����� (Melissa & Doug)",
							ShortDescription = "������������� ���� ������� ������ ������� ������� ����� �� 0 �� 20",
							Image = ImageHelper.ImageToByteArray(System.Drawing.Image.FromFile(MapPath(@"Content\Images\Shop\NumbersSoundPuzzle.jpg"), true)),
							Price = 989,
							Age = 5,
							ProductCount = 1,
							Size = "34x34",
							Description = "<p>������������� ���� ������� ������ ������� ������� ����� �� 0 �� 20.</p><ol><li>���������� ������ � ����� �� 0 �� 20</li><li>��� ����� ��������</li><li>�������� ����� � ��������������� ������, �� ��������, ��� ������ ����� ��-���������.</li><li>��� ������ ������ �������� �������� ��������. ���������� ��������� �� �������� �������������  ���������� �����. </li></ol>  <p>������������� ���� �������� �� ���� �������� ���.</p>",
							Video = "<iframe width=\"100%\" height=\"auto\" src=\"//www.youtube.com/embed/XMZJU81-gwE\" frameborder=\"0\" allowfullscreen></iframe>"
						};
			var item8 = new CatalogItemModel
						{
							Name = "������������� ����-������� (Melissa & Doug)",
							ShortDescription = "������������� ���� ������� ������ ������� ������� ���������� ������� � 26 ����� ����.",
							Image = ImageHelper.ImageToByteArray(System.Drawing.Image.FromFile(MapPath(@"Content\Images\Shop\AlphabetSoundPuzzle.jpg"), true)),
							Price = 989,
							Age = 5,
							ProductCount = 1,
							Size = "34x34",
							Description = "<ul><li>���������� ������ � ����� �� A �� Z</li><li>��� ����� ��������: �������� ����� � ��������������� ������, �� �������� �������� ����� � �����, ������������ � ���� �����.</li><li>��� ������ ������ �������� �������� ����������� ���������, �������� ������� ���������� � ��������� �����.</li></ul><p>������������� ���� �������� �� ���� �������� ���.</p>",
							Video = "<iframe width=\"100%\" height=\"auto\" src=\"//www.youtube.com/embed/XMZJU81-gwE\" frameborder=\"0\" allowfullscreen></iframe>"
						};
			var item9 = new CatalogItemModel
						{
							Name = "��������� ��������� (Educational Insights)",
							ShortDescription = "������������� ������� \"��������� ���������\" ������� ������ ������� ��������� ����� ����������� ��������, �����, ������� �������� �����, ��������� ������ � ���������� ������� ����� �� ���� ����.",
							Image = ImageHelper.ImageToByteArray(System.Drawing.Image.FromFile(MapPath(@"Content\Images\Shop\PhonicsFirefly.jpg"), true)),
							Price = 1599,
							Age = 5,
							ProductCount = 1,
							Size = "34x34",
							Description = "<h4>7 ��������� ������� ������:</h4><ol><li>����� \"���������� �������\"</li><li>�������� ������ �����</li><li>��������� �� ������ ����</li><li>�������� ������, ������� �������� ������ ����� ��������</li><li>��������� �� ������ ������</li><li>�������� ������� ������, ��������� �� 3� ����</li><li>��������� ���� ����� �� ���� ���� � ����������, ��� ��� ������!</li><p>��������� ������������. ������� ��������������� ����������. \"��������� ���������\" �������� �� 4 �������� �� (������ � ��������).<p>",
							Video = "<iframe width=\"100%\" height=\"auto\" src=\"//www.youtube.com/embed/CCHq0IG03wc\" frameborder=\"0\" allowfullscreen></iframe>"
						};
			var item10 = new CatalogItemModel
						 {
							 Name = "�������� ���� (LeapFrog)",
							 ShortDescription = "��� ������������� ������� ������� ������ ������� ��������� ����� ����������� ��������, �����, ������� �������� �����, � ����� ��������� ������ ����� (��������� � ��������).",
							 Image = ImageHelper.ImageToByteArray(System.Drawing.Image.FromFile(MapPath(@"Content\Images\Shop\Scribble&Write.jpg"), true)),
							 Price = 989,
							 Age = 6,
							 ProductCount = 1,
							 Size = "34x34",
							 Description = "<h4>4 ������ ������:</h4><ol><li><b>�������� ��������� ����</b><br/>������������ ����� �� ������ ������� ��������� ������ ����� (������, ���������), ������, ����������� � ��. ��������.</li><li><b>�������� ������ (��������� �����)</b><br/>������������ ����� �� ������ ���������, ��� ��������� �������� ��������� ����� ����������� ��������.</li><li><b>�������� ������ (�������� �����)</b><br/>������������ ����� �� ������ ���������, ��� ��������� �������� �������� ����� ����������� ��������.</li><li><b>�������� ������<br/>��������, ����� ����� ���������� �� ������.</b></li><li><p>��� ������ ���� �� ������ ������������ ������, ������� ���������� ���������� ��� ��������� ���� �������. ����� ������� ������������ ������� �� �������� ������ ����� ������. �������� �������� �� ���� �������� �� (������ � ��������).</p>",
							 Video = "<iframe width=\"100%\" height=\"auto\" src=\"//www.youtube.com/embed/QGej3eBNpnc\" frameborder=\"0\" allowfullscreen></iframe>"
						 };
			var item11 = new CatalogItemModel
						 {
							 Name = "��������� ����� (LeapFrog)",
							 ShortDescription = "������������� \"��������� �����\" ������� ������ ������� ������� ����� �� 1 �� 20, �������� ��������, ������ � �������, � ����� ���������� ����� � ���������� ���������.",
							 Image = ImageHelper.ImageToByteArray(System.Drawing.Image.FromFile(MapPath(@"Content\Images\Shop\TouchMagic%20CountingTrain.jpg"), true)),
							 Price = 1199,
							 Age = 5,
							 ProductCount = 1,
							 Size = "34x34",
							 Description = "<h4>3 ������ ������:</h4><ul><li>���������<br/>���������� ����� �� 1 �� 20, ������� �������� ��������, ������ � ������� (20 ����� ����)</li><li>�����������<br/>��������� (������� ������. ������� 2 ������ ����������. ������� 3 ������ ��������.)</li><li>�����������<br/>������ ��������� ���������� ������� � �������� \"Old MacDonald\". �� ������ ������� ���� ������ �����!</li><li><p>\"��������� �����\" �������� �� 3 �������� ��� (������ � ��������).</p>",
							 Video = "<iframe width=\"100%\" height=\"auto\" src=\"//www.youtube.com/embed/DmEBLgP2DaE\" frameborder=\"0\" allowfullscreen></iframe>"
						 };

			var catalogItems = new List<CatalogItemModel>() { item0, item1, item2, item2, item4, item5, item6, item7, item8, item9, item10, item11 };
			PopulateSamllImages(catalogItems);
			context.CatalogItemModels.AddRange(catalogItems);
			
		}

		public void PopulateSamllImages(List<CatalogItemModel> catalogItems)
		{
			foreach (var item in catalogItems)
			{
				var ms = new MemoryStream(item.Image);
				var returnImage = Image.FromStream(ms);
				var t = ImageHelper.ScaleImage(returnImage, 280, 200);
				item.SmallImage = ImageHelper.ImageToByteArray(t);
			}
		}
	}
}
