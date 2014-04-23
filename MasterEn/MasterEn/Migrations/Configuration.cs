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
							Name = "Обучающий плеер (WinFun)",
							ShortDescription = "Интерактивный обучающий плеер поможет вашему ребенку выучить буквы алфавита, звуки, которые передают буквы, а также 26 английских слов.",
							Image = ImageHelper.ImageToByteArray(System.Drawing.Image.FromFile(MapPath(@"Content\Images\Shop\TalkingAlphabetPlayer.jpg"), true)),
							Price = 989,
							Age = 5,
							ProductCount = 1,
							Size = "34x34",
							Description = "<h4>5 режимов работы:</h4><ol><li><b>Обучающий 1.</b> Узнайте, как произносятся английские слова, с какой буквы начинается каждое слово и какой звук передает каждая буква.</li><li><b>Обучающий 2.</b> Научитесь произносить слова по буквам. Этот навык поможет запомнить английские буквы, а также написание слов.</li><li><b>Тестирующий 1</b> (Какая буква следует за буквой U?)</li><li><b>Тестирующий 2</b> (С какой буквы начинается слово Leg?)</li><li><b>Музыкальный</b></li></ol><p>Благодаря удобной ручке, плеер удобно брать с собой в дорогу. Обучающий плеер работает от 2 батареек АА (входят в комплект).</p>",
							Video = "<iframe width=\"100%\" height=\"auto\" src=\"//www.youtube.com/embed/NkK0Dryk1Js\" frameborder=\"0\" allowfullscreen></iframe>"
						};
			var item1 = new CatalogItemModel
						{
							Name = "Фабрика букв (LeapFrog)",
							ShortDescription = "'Фабрика букв' поможет вашему ребенку выучить английский алфавит.",
							Image = ImageHelper.ImageToByteArray(System.Drawing.Image.FromFile(MapPath(@"Content\Images\Shop\LetterFactory.jpg"), true)),
							Price = 969,
							Age = 3,
							ProductCount = 1,
							Size = "34x34",
							Description = "<p>В комплект входят 26 объемных букв и \"фабрика\", с помощью которой буквы \"оживают\" - вы узнаете название буквы, какой звук она передает. И для лучшего запоминания - веселая песенка для каждой буквы!</p><p>\"Фабрика букв\" работает от 3 батареек ААА.</p>",
							Video = "<iframe width=\"100%\" height=\"auto\" src=\"//www.youtube.com/embed/FR3jsROCYQ0\" frameborder=\"0\" allowfullscreen></iframe>"
						};
			var item2 = new CatalogItemModel
						{
							Name = "Тренажер цифр (LeapFrog)",
							ShortDescription = "Эта интерактивная игрушка поможет вашему ребенку запомнить английские цифры, а также научиться их писать.",
							Image = ImageHelper.ImageToByteArray(System.Drawing.Image.FromFile(MapPath(@"Content\Images\Shop\Count&Draw.jpg"), true)),
							Price = 979,
							Age = 5,
							ProductCount = 1,
							Size = "34x34",
							Description = "<h4>3 режима работы:</h4><ol><li><b>Обучение элементам цифр.</b> Подсвеченные точки на экране помогут начертить ровные линии (прямые, наклонные), кривые, закругления и др. элементы.</li><li><b>Обучение письму (цифры).</b> Подсвеченные точки на экране подскажут, как правильно написать каждую цифру.</li><li><b>Обучение счету.</b> Подсчитайте количество подсвеченных точек на экране.</li></ol><p>Для письма цифр на экране используется стилус, который специально разработан для маленькой руки ребенка.</p><p>После каждого выполненного задания вы услышите оценку своей работы.<p><p>Тренажер работает от трех батареек АА (входят в комплект).</p>",
							Video = "<iframe width=\"100%\" height=\"auto\" src=\"//www.youtube.com/embed/t9hyJPFgIws\" frameborder=\"0\" allowfullscreen></iframe>"
						};
			var item4 = new CatalogItemModel
						{
							Name = "Интерактивная книга \"Волшебная черепашка\" (VTech)",
							ShortDescription = "Интерактивная книга \"Волшебная черепашка\" поможет вашему ребенку выучить буквы английского алфавита, 26 новых слов, геометрические формы и цифры.",
							Image = ImageHelper.ImageToByteArray(System.Drawing.Image.FromFile(MapPath(@"Content\Images\Shop\Touch&Teach%20Turtle.jpg"), true)),
							Price = 899,
							Age = 5,
							ProductCount = 1,
							Size = "34x34",
							Description = "<h4>3 режима работы:</h4><ol><li><b>Режим букв</b><br/>Послушайте названия букв и слова, соответствующие каждой букве алфавита</li><li><b>Режим \"Расскажи сказку\"</b><br />Черепашка прочитает все фразы в книге и озвучит все звуки животных</li><li><b>Музыкальный режим</b><br />Повторите все буквы и слова под веселую мелодию</li></ol><p>16 страниц, обучающих буквам и геометрическим формам (круг, квадрат, треугольник и т.д.)</p><p>Разноцветные светящиеся кнопки делают процесс обучения более увлекательным.</p><p>8  кнопок на лапках черепашки научат  цифрам (от 1 до 8) и музыке.</p><p>Разноцветные светящиеся кнопки делают процесс обучения более увлекательным.</p><p>Благодаря удобной ручке, книгу удобно брать с собой в дорогу.</p><p>Интерактивная черепашка работает от 2 батареек АА (входят в комплект).</p>",
							Video = "<iframe width=\"100%\" height=\"auto\" src=\"//www.youtube.com/embed/9fcNTtRTFWU\" frameborder=\"0\" allowfullscreen></iframe>"
						};

			var item5 = new CatalogItemModel
						{
							Name = "Интерактивный словарик (VTech)",
							ShortDescription = "Интерактивный словарик поможет вашему ребенку запомнить 100 слов из 6 категорий (продукты, животные и т.д.).",
							Image = ImageHelper.ImageToByteArray(System.Drawing.Image.FromFile(MapPath(@"Content\Images\Shop\Touch&TeachWordBook1.jpg"), true)),
							Price = 1199,
							Age = 7,
							ProductCount = 1,
							Size = "34x34",
							Description = "<h4>4 режима работы:</h4><ol><li><b>Обучающий 1</b><br>Что это? Прикоснувшись к картинке, вы услышите название предмета и его характерный звук</li><li><b>Обучающий 2</b><br>Веселые буквы. Узнайте, с какой буквы начинается каждое слово.</li><li><b>Музыкальная пауза</b></li><li><b>Тестирующий</b></li><p>Викторина. Прослушайте название предмета  и найдите соответствующую картинку.</p></ol><p>12 страниц, более 100 слов из 6 различных категорий: дом, продукты, одежда, животные, игрушки и игровая площадка. На страницах книги вас будут сопровождать веселые персонажи - щенки Коди и Кора.Небольшой размер позволяет брать книгу с собой в дорогу. Интерактивный словарик работает от двух батареек ААА (входят в комплект).</p>",
							Video = "<iframe width=\"100%\" height=\"auto\" src=\"//www.youtube.com/embed/YK4zs2YAxVo\" frameborder=\"0\" allowfullscreen></iframe>"
						};

			var item6 = new CatalogItemModel
						{
							Name = "Волшебный автобус (LeapFrog)",
							ShortDescription = "Интерактивный \"Волшебный автобус\" поможет вашему ребенку выучить английский алфавит и 26 новых слов, соответствующих каждой букве.",
							Image = ImageHelper.ImageToByteArray(System.Drawing.Image.FromFile(MapPath(@"Content\Images\Shop\TouchMagicLearningBus.jpg"), true)),
							Price = 989,
							Age = 5,
							ProductCount = 1,
							Size = "34x34",
							Description = "<h4>3 режима работы:</h4><ol><li><b>Обучающий</b><br />Узнай, как называются буквы английского алфавита, какие звуки они передают и новое слово на каждую букву. Все слова сопровождаются забавными звуками, которые издают животные и предметы.</li><li><b>Тестирующий</b><br />Викторина. (Найди букву О. Какой предмет издает этот звук?)<li><b>Музыкальный</b></li></ol><p>Интерактивный автобус работает от 3 батареек ААА (входят в комплект).</p>",
							Video = "<iframe width=\"100%\" height=\"auto\" src=\"//www.youtube.com/embed/dLjXsctwJi0\" frameborder=\"0\" allowfullscreen></iframe>"
						};
			var item7 = new CatalogItemModel
						{
							Name = "Интерактивный пазл-числа (Melissa & Doug)",
							ShortDescription = "Интерактивный пазл поможет вашему ребенку выучить числа от 0 до 20",
							Image = ImageHelper.ImageToByteArray(System.Drawing.Image.FromFile(MapPath(@"Content\Images\Shop\NumbersSoundPuzzle.jpg"), true)),
							Price = 989,
							Age = 5,
							ProductCount = 1,
							Size = "34x34",
							Description = "<p>Интерактивный пазл поможет вашему ребенку выучить числа от 0 до 20.</p><ol><li>Деревянная основа и цифры от 0 до 20</li><li>Все цифры озвучены</li><li>Поместив цифру в соответствующую ячейку, вы услышите, как звучит число по-английски.</li><li>Под каждым числом спрятаны забавные картинки. Количество предметов на картинке соответствует  указанному числу. </li></ol>  <p>Интерактивный пазл работает от трех батареек ААА.</p>",
							Video = "<iframe width=\"100%\" height=\"auto\" src=\"//www.youtube.com/embed/XMZJU81-gwE\" frameborder=\"0\" allowfullscreen></iframe>"
						};
			var item8 = new CatalogItemModel
						{
							Name = "Интерактивный пазл-алфавит (Melissa & Doug)",
							ShortDescription = "Интерактивный пазл поможет вашему ребенку выучить английский алфавит и 26 новых слов.",
							Image = ImageHelper.ImageToByteArray(System.Drawing.Image.FromFile(MapPath(@"Content\Images\Shop\AlphabetSoundPuzzle.jpg"), true)),
							Price = 989,
							Age = 5,
							ProductCount = 1,
							Size = "34x34",
							Description = "<ul><li>Деревянная основа и буквы от A до Z</li><li>Все буквы озвучены: поместив букву в соответствующую ячейку, вы услышите название буквы и слово, начинающееся с этой буквы.</li><li>Под каждой буквой спрятаны забавные изображения предметов, название которых начинается с указанной буквы.</li></ul><p>Интерактивный пазл работает от трех батареек ААА.</p>",
							Video = "<iframe width=\"100%\" height=\"auto\" src=\"//www.youtube.com/embed/XMZJU81-gwE\" frameborder=\"0\" allowfullscreen></iframe>"
						};
			var item9 = new CatalogItemModel
						{
							Name = "Волшебный светлячок (Educational Insights)",
							ShortDescription = "Интерактивная игрушка \"Волшебный светлячок\" поможет вашему ребенку запомнить буквы английского алфавита, звуки, которые передают буквы, научиться читать и составлять простые слова из трех букв.",
							Image = ImageHelper.ImageToByteArray(System.Drawing.Image.FromFile(MapPath(@"Content\Images\Shop\PhonicsFirefly.jpg"), true)),
							Price = 1599,
							Age = 5,
							ProductCount = 1,
							Size = "34x34",
							Description = "<h4>7 обучающих режимов работы:</h4><ol><li>Песня \"Английский алфавит\"</li><li>Название каждой буквы</li><li>Викторина на знание букв</li><li>Обучение звукам, которые передает каждая буква алфавита</li><li>Викторина на знание звуков</li><li>Обучение простым словам, состоящих из 3х букв</li><li>Составьте свое слово из трех букв и послушайте, как оно звучит!</li><p>Громкость регулируется. Функция автоматического выключения. \"Волшебный светлячок\" работает от 4 батареек АА (входят в комплект).<p>",
							Video = "<iframe width=\"100%\" height=\"auto\" src=\"//www.youtube.com/embed/CCHq0IG03wc\" frameborder=\"0\" allowfullscreen></iframe>"
						};
			var item10 = new CatalogItemModel
						 {
							 Name = "Тренажер букв (LeapFrog)",
							 ShortDescription = "Эта интерактивная игрушка поможет вашему ребенку запомнить буквы английского алфавиты, звуки, которые передают буквы, а также научиться писать буквы (заглавные и строчные).",
							 Image = ImageHelper.ImageToByteArray(System.Drawing.Image.FromFile(MapPath(@"Content\Images\Shop\Scribble&Write.jpg"), true)),
							 Price = 989,
							 Age = 6,
							 ProductCount = 1,
							 Size = "34x34",
							 Description = "<h4>4 режима работы:</h4><ol><li><b>Обучение элементам букв</b><br/>Подсвеченные точки на экране помогут начертить ровные линии (прямые, наклонные), кривые, закругления и др. элементы.</li><li><b>Обучение письму (заглавные буквы)</b><br/>Подсвеченные точки на экране подскажут, как правильно написать заглавные буквы английского алфавита.</li><li><b>Обучение письму (строчные буквы)</b><br/>Подсвеченные точки на экране подскажут, как правильно написать строчные буквы английского алфавита.</li><li><b>Проверка знаний<br/>Угадайте, какая буква изображена на экране.</b></li><li><p>Для письма букв на экране используется стилус, который специально разработан для маленькой руки ребенка. После каждого выполненного задания вы услышите оценку своей работы. Тренажер работает от трех батареек АА (входят в комплект).</p>",
							 Video = "<iframe width=\"100%\" height=\"auto\" src=\"//www.youtube.com/embed/QGej3eBNpnc\" frameborder=\"0\" allowfullscreen></iframe>"
						 };
			var item11 = new CatalogItemModel
						 {
							 Name = "Волшебный поезд (LeapFrog)",
							 ShortDescription = "Интерактивный \"Волшебный поезд\" поможет вашему ребенку выучить цифры от 1 до 20, названия животных, овощей и фруктов, а также соотносить цифру и количество предметов.",
							 Image = ImageHelper.ImageToByteArray(System.Drawing.Image.FromFile(MapPath(@"Content\Images\Shop\TouchMagic%20CountingTrain.jpg"), true)),
							 Price = 1199,
							 Age = 5,
							 ProductCount = 1,
							 Size = "34x34",
							 Description = "<h4>3 режима работы:</h4><ul><li>обучающий<br/>Послушайте цифры от 1 до 20, узнайте названия животных, овощей и фруктов (20 новых слов)</li><li>тестирующий<br/>Викторина (Найдите яблоки. Найдите 2 шарика мороженого. Найдите 3 желтых цыпленка.)</li><li>музыкальный<br/>Спойте известную английскую песенку о животных \"Old MacDonald\". Вы можете создать свою версию песни!</li><li><p>\"Волшебный поезд\" работает от 3 батареек ААА (входят в комплект).</p>",
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
