#pragma checksum "G:\CreArtHub\CreArtHub\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "df687b2e72bb163721956141b87aa1596659ded6"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(CreArtHub.Pages.Home.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
namespace CreArtHub.Pages.Home
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "G:\CreArtHub\CreArtHub\Views\_ViewImports.cshtml"
using CreArtHub;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"df687b2e72bb163721956141b87aa1596659ded6", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"62e1f44415acbdc722fa39ff9171a56a3c230e0e", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<CreArtHub.Shared.Model.HomeModel>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Account", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Register", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("target", new global::Microsoft.AspNetCore.Html.HtmlString("_blank"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-main"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "G:\CreArtHub\CreArtHub\Views\Home\Index.cshtml"
  
	Layout = "_Layout";
	//ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<section class=\"hero-area\">\r\n\t<div class=\"container\">\r\n\t\t<div class=\"row\">\r\n\t\t\t<div class=\"col-md-6\">\r\n\t\t\t\t<div class=\"video-player\">\r\n\t\t\t\t\t<img src=\"images/welcomeImage.png\" class=\"img-fluid rounded\"");
            BeginWriteAttribute("alt", " alt=\"", 305, "\"", 311, 0);
            EndWriteAttribute();
            WriteLiteral(@">
				</div>
			</div>
			<div class=""col-md-6"">
				<div class=""block"">
					<h2>Мы помогаем авторам развиваться</h2>
					<p>Мы верим в силу слова, и поэтому предоставляем уникальные инструменты, ресурсы и платформу для ваших творческих идей. У нас вы найдете сообщество, готовое поддержать вас на каждом этапе вашего творческого пути. </p>
					<ul class=""list-inline wow fadeInUp"" data-wow-duration="".5s"" data-wow-delay="".7s"">
						<li class=""list-inline-item"">
							");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "df687b2e72bb163721956141b87aa1596659ded65873", async() => {
                WriteLiteral("Зарегестрироваться");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
						</li>
					</ul>
				</div>
			</div>
		</div>
	</div>
</section>

<!--
Start About Section
==================================== -->
<section class=""about-2 section bg-gray"" id=""about"">
	<div class=""container"">
		<div class=""row"">
			<div class=""col-12 col-md-5"">
				<h2>Наша площадка содержит разнообразный авторский контент</h2>
			</div>
			<div class=""col-12 col-md-7"">
				<p>
					Мы гордимся разнообразием и уникальностью творческих голосов нашего сообщества. Наша площадка с радостью приветствует авторов, создающих контент в самых разных жанрах и направлениях.
					Будь это тексты, фотографии, видео, музыка, или искусство в разных его проявлениях - у нас есть место для вашего таланта.
				</p>
				<p>
					Мы ценим креативность и индивидуальность каждого автора и стремимся создать для вас идеальное окружение, где вы можете делиться своими идеями и найти свою аудиторию.
					Наша площадка - это место, где многообразие контента и авторских голосов процветает.
				</p>
			</");
            WriteLiteral(@"div>

		</div> 		<!-- End row -->
	</div>   	<!-- End container -->
</section>   <!-- End section -->

<section class=""services section-xs"" id=""services"">
	<div class=""container"">
		<div class=""row"">
			<!-- Single Service Item -->
			<div class=""col-md-4 col-sm-6 col-xs-12"">
				<div class=""service-block color-bg text-center"">
					<div class=""service-icon text-center"">
						<i class=""tf-ion-ios-musical-note""></i>
					</div>
					<h3>Музыка</h3>
					<p>Погрузитесь в мир музыкальных эмоций, наслаждайтесь уникальными мелодиями и поддерживайте творчество авторов. Наша площадка - это гармония звуков для всех.</p>
				</div>
			</div>
			<!-- End Single Service Item -->
			<!-- Single Service Item -->
			<div class=""col-md-4 col-sm-6 col-xs-12"">
				<div class=""service-block text-center"">
					<div class=""service-icon text-center"">
						<i class=""tf-ion-ios-photos-outline""></i>
					</div>
					<h3>Изображения</h3>
					<p>У нас есть как платный, так и бесплатный контент, призванный");
            WriteLiteral(@" вдохновлять и поражать воображение.</p>
				</div>
			</div>
			<!-- End Single Service Item -->
			<!-- Single Service Item -->
			<div class=""col-md-4 col-sm-6 col-xs-12 mx-auto"">
				<div class=""service-block color-bg text-center"">
					<div class=""service-icon text-center"">
						<i class=""tf-ion-ios-videocam-outline""></i>
					</div>
					<h3>Медиа &amp; Реклама</h3>
					<p>Поддерживайте креатив и вдохновляйтесь нашими работами, чтобы сделать вашу медийную и рекламную компанию неповторимой.</p>
				</div>
			</div>
		</div> 		<!-- End row -->
	</div>   	<!-- End container -->
</section>   <!-- End section -->

<section class=""about section-sm"" id=""about"">
	<div class=""container"">
		<div class=""row mb-50 justify-content-center"">
			<div class=""col-md-5 col-sm-12 text-center offset-md-1"">
				<img src=""images/about/about-1.jpg"" class=""img-fluid rounded shadow""");
            BeginWriteAttribute("alt", " alt=\"", 3851, "\"", 3857, 0);
            EndWriteAttribute();
            WriteLiteral(@">
			</div>
			<div class=""col-md-5 col-sm-12"">
				<div class=""content"">
					<h2>Творчество в нашей <br> крови</h2>
					<p>
						У нас в сердце и душе бьется страсть к творчеству. Наша платформа - место, где каждая капля вдохновения становится произведением искусства.
						Мы гордимся поддерживать разнообразие авторов, предоставляя платный и бесплатный контент для творческих душ.
				</div>

				</p>
			</div>
		</div> 		<!-- End row -->
		<div class=""row mt-50 justify-content-center"">
			<div class=""col-12 col-md-5 offset-md-1 col-md-5 col-sm-12"">
				<div class=""content"">
					<h2>Мы думаем <br> нестандартно</h2>
					<p>
						Мы - место, где размышление выходит за рамки обыденного. На нашей платформе мы приветствуем и поощряем авторов, которые видят мир по-своему и готовы поделиться своей уникальной перспективой.
						Здесь вы найдете как платный, так и бесплатный контент, который вдохновляет и заставляет думать нестандартно.
				</div>

				</p>
			</div>
			<div class=""col-");
            WriteLiteral("12 col-md-5 col-sm-12 text-center\">\r\n\t\t\t\t<img src=\"images/about/about-2.jpg\" class=\"img-fluid rounded shadow\"");
            BeginWriteAttribute("alt", " alt=\"", 4991, "\"", 4997, 0);
            EndWriteAttribute();
            WriteLiteral(@">
			</div>
		</div> 		<!-- End row -->
	</div>   	<!-- End container -->
</section>   <!-- End section -->
<!--
Start About Section
==================================== -->
<!-- Start Portfolio Section
=========================================== -->
");
#nullable restore
#line 132 "G:\CreArtHub\CreArtHub\Views\Home\Index.cshtml"
 if (Model.FileDtos.Any())
{

#line default
#line hidden
#nullable disable
            WriteLiteral(@"	<section class=""portfolio section"" id=""portfolio"">
		<div class=""container-fluid"">
			<div class=""row"">
				<div class=""col"">
					<div class=""title text-center"">
						<h4>ДОСТУПНЫЕ РАБОТЫ</h4>
						<h2>РАБОТЫ</h2>
						<span class=""border""></span>
						<p>В данном разделе представлены работы автора, как для платной, так и для бесплатной основы.</p>
					</div>
				</div>
			</div>
				<div class=""row"">
					<div class=""col-lg-12"">
						<!-- /section title -->
						<div class=""portfolio-filter"">
							<button type=""button"" data-filter=""all"">Все</button>
");
#nullable restore
#line 151 "G:\CreArtHub\CreArtHub\Views\Home\Index.cshtml"
                              
								var Categories = Model.FileDtos
								.Select(x => x.Post.Category.Name)
								.Distinct()
								.ToList();
								foreach (var category in Categories)
								{
									if (category != null)
									{

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t\t\t\t\t\t\t<button type=\"button\" data-filter=\".");
#nullable restore
#line 160 "G:\CreArtHub\CreArtHub\Views\Home\Index.cshtml"
                                                                       Write(category.Replace(' ','_'));

#line default
#line hidden
#nullable disable
            WriteLiteral("\">");
#nullable restore
#line 160 "G:\CreArtHub\CreArtHub\Views\Home\Index.cshtml"
                                                                                                   Write(category);

#line default
#line hidden
#nullable disable
            WriteLiteral("</button>\r\n");
#nullable restore
#line 161 "G:\CreArtHub\CreArtHub\Views\Home\Index.cshtml"
									}
								}
							

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t\t\t</div>\r\n\t\t\t\t\t</div>\r\n\t\t\t\t</div> <!-- /end col-lg-12 -->\r\n\t\t\t\t<div class=\"row portfolio-items-wrapper\">\r\n");
#nullable restore
#line 168 "G:\CreArtHub\CreArtHub\Views\Home\Index.cshtml"
                     foreach (var el in Model.FileDtos)
					{

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t\t\t<div");
            BeginWriteAttribute("class", " class=\"", 6410, "\"", 6486, 5);
            WriteAttributeValue("", 6418, "col-6", 6418, 5, true);
            WriteAttributeValue(" ", 6423, "col-md-4", 6424, 9, true);
            WriteAttributeValue(" ", 6432, "padding-0", 6433, 10, true);
            WriteAttributeValue(" ", 6442, "mix", 6443, 4, true);
#nullable restore
#line 170 "G:\CreArtHub\CreArtHub\Views\Home\Index.cshtml"
WriteAttributeValue(" ", 6446, el.Post.Category.Name.Replace(' ','_'), 6447, 39, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n\t\t\t\t\t\t\t<div class=\"portfolio-block\">\r\n");
#nullable restore
#line 172 "G:\CreArtHub\CreArtHub\Views\Home\Index.cshtml"
                                 if (!string.IsNullOrEmpty(el.Post.ImgPath))
								{

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t\t\t\t\t\t<img class=\"img-fluid\"");
            BeginWriteAttribute("src", " src=", 6624, "", 6645, 1);
#nullable restore
#line 174 "G:\CreArtHub\CreArtHub\Views\Home\Index.cshtml"
WriteAttributeValue("", 6629, el.Post.ImgPath, 6629, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 6645, "\"", 6651, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n");
#nullable restore
#line 175 "G:\CreArtHub\CreArtHub\Views\Home\Index.cshtml"
								}
								else
								{

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t\t\t\t\t\t<img class=\"img-fluid\" src=\"/images/portfolio/portfolio-1.jpg\"");
            BeginWriteAttribute("alt", " alt=\"", 6762, "\"", 6768, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n");
#nullable restore
#line 179 "G:\CreArtHub\CreArtHub\Views\Home\Index.cshtml"
								}

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t\t\t\t\t<div class=\"caption\">\r\n");
#nullable restore
#line 181 "G:\CreArtHub\CreArtHub\Views\Home\Index.cshtml"
                                     if (!string.IsNullOrEmpty(el.Post.ImgPath))
									{

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t\t\t\t\t\t\t<a class=\"search-icon\"");
            BeginWriteAttribute("href", " href=", 6913, "", 6935, 1);
#nullable restore
#line 183 "G:\CreArtHub\CreArtHub\Views\Home\Index.cshtml"
WriteAttributeValue("", 6919, el.Post.ImgPath, 6919, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" data-lightbox=\"image-1\">\r\n\t\t\t\t\t\t\t\t\t\t\t<i class=\"tf-ion-ios-search-strong\"></i>\r\n\t\t\t\t\t\t\t\t\t\t</a>\r\n");
#nullable restore
#line 186 "G:\CreArtHub\CreArtHub\Views\Home\Index.cshtml"
									}
									else
									{

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t\t\t\t\t\t\t<a class=\"search-icon\" href=\"/images/portfolio/portfolio-1.jpg\" data-lightbox=\"image-1\">\r\n\t\t\t\t\t\t\t\t\t\t\t<i class=\"tf-ion-ios-search-strong\"></i>\r\n\t\t\t\t\t\t\t\t\t\t</a>\r\n");
#nullable restore
#line 192 "G:\CreArtHub\CreArtHub\Views\Home\Index.cshtml"
									}

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t\t\t\t\t\t<h4>");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "df687b2e72bb163721956141b87aa1596659ded618041", async() => {
#nullable restore
#line 193 "G:\CreArtHub\CreArtHub\Views\Home\Index.cshtml"
                                                                                                         Write(el.FileName);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 193 "G:\CreArtHub\CreArtHub\Views\Home\Index.cshtml"
                                                                                       WriteLiteral(el.PostId);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</h4>\r\n\t\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t</div>\r\n");
#nullable restore
#line 197 "G:\CreArtHub\CreArtHub\Views\Home\Index.cshtml"
					}

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t</div>\r\n\t\t</div> <!-- end row -->\r\n\t</section>\r\n");
#nullable restore
#line 201 "G:\CreArtHub\CreArtHub\Views\Home\Index.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<!-- Start Our Team
		=========================================== -->
<!-- Start Pricing section
		=========================================== -->
<!-- Start Testimonial
=========================================== -->
<!--
Start Blog Section
=========================================== -->
");
#nullable restore
#line 211 "G:\CreArtHub\CreArtHub\Views\Home\Index.cshtml"
 if (Model.PostDtos.Any())
{

#line default
#line hidden
#nullable disable
            WriteLiteral(@"	<section class=""blog section"" id=""blog"">
		<div class=""container"">
			<div class=""row"">
				<div class=""col"">
					<div class=""title text-center"">
						<h4>Наши истории</h4>
						<h2>БЛОГ</h2>
						<span class=""border""></span>
						<p>Добро пожаловать в наш мир размышлений и идей! </p>
					</div>
				</div>
			</div>
			<div class=""row"">
			
");
#nullable restore
#line 227 "G:\CreArtHub\CreArtHub\Views\Home\Index.cshtml"
                 foreach( var el in Model.PostDtos)
				{

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t\t<article class=\"col-12 col-md-4\">\r\n\t\t\t\t\t\t<div class=\"post-item\">\r\n\t\t\t\t\t\t\t<div class=\"post-thumb\">\r\n");
#nullable restore
#line 232 "G:\CreArtHub\CreArtHub\Views\Home\Index.cshtml"
                                 if(el.ImgPath != string.Empty)
								{  

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t\t\t\t\t\t<img class=\"img-fluid shadow rounded\"");
            BeginWriteAttribute("src", " src=", 8411, "", 8427, 1);
#nullable restore
#line 234 "G:\CreArtHub\CreArtHub\Views\Home\Index.cshtml"
WriteAttributeValue("", 8416, el.ImgPath, 8416, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" alt=\"Generic placeholder image\">\r\n");
#nullable restore
#line 235 "G:\CreArtHub\CreArtHub\Views\Home\Index.cshtml"
								} 
								else
								{

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t\t\t\t\t\t<img class=\"img-fluid shadow rounded\" src=\"images/blog/post-1.jpg\" alt=\"Generic placeholder image\">\r\n");
#nullable restore
#line 239 "G:\CreArtHub\CreArtHub\Views\Home\Index.cshtml"
								}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t\t<div class=\"post-title\">\r\n\t\t\t\t\t\t\t\t<h3 class=\"mt-0\">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "df687b2e72bb163721956141b87aa1596659ded623588", async() => {
#nullable restore
#line 243 "G:\CreArtHub\CreArtHub\Views\Home\Index.cshtml"
                                                                                                                Write(el.Title);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-Id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 243 "G:\CreArtHub\CreArtHub\Views\Home\Index.cshtml"
                                                                                                 WriteLiteral(el.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["Id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-Id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["Id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</h3>\r\n\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t\t<div class=\"post-meta\">\r\n\t\t\t\t\t\t\t\t<span>Автор&nbsp;</span> <a");
            BeginWriteAttribute("href", " href=\"", 8865, "\"", 8872, 0);
            EndWriteAttribute();
            BeginWriteAttribute("class", " class=\"", 8873, "\"", 8881, 0);
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 246 "G:\CreArtHub\CreArtHub\Views\Home\Index.cshtml"
                                                                        Write(el.Author.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t\t<div class=\"post-content\">\r\n");
#nullable restore
#line 249 "G:\CreArtHub\CreArtHub\Views\Home\Index.cshtml"
                                 if (@el.Content.Length > 50)
								{

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t\t\t\t\t\t<p>");
#nullable restore
#line 251 "G:\CreArtHub\CreArtHub\Views\Home\Index.cshtml"
                                  Write(el.Content.Substring(0,50));

#line default
#line hidden
#nullable disable
            WriteLiteral("...</p>\r\n");
#nullable restore
#line 252 "G:\CreArtHub\CreArtHub\Views\Home\Index.cshtml"

								}
								else
								{

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t\t\t\t\t\t<p>");
#nullable restore
#line 256 "G:\CreArtHub\CreArtHub\Views\Home\Index.cshtml"
                                  Write(el.Content);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n");
#nullable restore
#line 257 "G:\CreArtHub\CreArtHub\Views\Home\Index.cshtml"
								}

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t\t");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "df687b2e72bb163721956141b87aa1596659ded628033", async() => {
                WriteLiteral("Открыть");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-Id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 259 "G:\CreArtHub\CreArtHub\Views\Home\Index.cshtml"
                                                                                                 WriteLiteral(el.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["Id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-Id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["Id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\t\t\t\t\t\t</div>\r\n\t\t\t\t\t</article>\r\n");
#nullable restore
#line 262 "G:\CreArtHub\CreArtHub\Views\Home\Index.cshtml"
				}

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\r\n\t\t\t</div> <!-- end row -->\r\n\t\t</div> <!-- end container -->\r\n\t</section> <!-- end section -->\r\n");
#nullable restore
#line 267 "G:\CreArtHub\CreArtHub\Views\Home\Index.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<CreArtHub.Shared.Model.HomeModel> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
