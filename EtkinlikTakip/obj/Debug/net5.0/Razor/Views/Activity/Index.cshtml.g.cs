#pragma checksum "C:\Users\emret\source\repos\EtkinlikTakip\EtkinlikTakip\Views\Activity\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5bce6b7a821eea5b8278d0874ba88b2fe7f320a8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Activity_Index), @"mvc.1.0.view", @"/Views/Activity/Index.cshtml")]
namespace AspNetCore
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
#line 1 "C:\Users\emret\source\repos\EtkinlikTakip\EtkinlikTakip\Views\_ViewImports.cshtml"
using EtkinlikTakip;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\emret\source\repos\EtkinlikTakip\EtkinlikTakip\Views\_ViewImports.cshtml"
using Kendo.Mvc.UI;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\emret\source\repos\EtkinlikTakip\EtkinlikTakip\Views\Activity\Index.cshtml"
using EntityLayer.Concrete;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\emret\source\repos\EtkinlikTakip\EtkinlikTakip\Views\Activity\Index.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5bce6b7a821eea5b8278d0874ba88b2fe7f320a8", @"/Views/Activity/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"001f787cbd88bb8d5344103ba02ed220c3129dd9", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Activity_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 5 "C:\Users\emret\source\repos\EtkinlikTakip\EtkinlikTakip\Views\Activity\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n<div>\r\n    ");
#nullable restore
#line 11 "C:\Users\emret\source\repos\EtkinlikTakip\EtkinlikTakip\Views\Activity\Index.cshtml"
Write(Html.Kendo().Scheduler<Activity>()
    .Name("scheduler")
    .Date(DateTime.Now)
    .StartTime(new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 09, 00, 00))
    .EndTime(new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 18, 00, 00))
    .Height(550)
    .Toolbar(t => {
    t.Search();
    t.GetType();
    })
    .Editable(edit=>{
    if (HttpContextAccessor.HttpContext.Session.GetString("userRole") == "Personel")
    {
    edit.Confirmation(false);
    edit.Create(false);
    edit.Move(false);
    edit.Resize(false);
    edit.Destroy(false);
    edit.EditRecurringMode(SchedulerEditRecurringMode.Occurrence);
    edit.TemplateId("activityDetailTemplate");
    }
    else{
    edit.TemplateId("customEditorTemplate");
    }
    })
    .EventTemplateId("customEventTemplate")
    .Events(e =>
    {
    e.Edit("scheduler_edit");
    })
    .Timezone("Etc/UTC")
    .Footer(false)
    .Views(views =>
    {
    views.DayView();
    views.WeekView(week =>
    {
    week.Selected(true);
    });
    views.MonthView(month => {
    month.AdaptiveSlotHeight(true);
    month.EventsPerDay(6);
    month.EventHeight("auto");
    });
    views.YearView(year => {
    year.Title("Yıl");
    });
    views.AgendaView();
    })
    .DataSource(d => d
    .Model(m =>
    {
    m.Id(f => f.ID);
    m.Field(f => f.Title).DefaultValue("Başlık yok");
    m.Field(f=> f.CreateTime).DefaultValue(DateTime.Now);
    })
    .Read("ActivityRead", "Activity")
    .Create("ActivityCreate", "Activity")
    .Update("ActivityUpdate", "Activity")
    .Destroy("ActivityDestroy", "Activity")
    )
    );

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</div>\r\n\r\n<script type=\"text/javascript\">\r\n    function scheduler_edit(e) {\r\n        var role = \'");
#nullable restore
#line 77 "C:\Users\emret\source\repos\EtkinlikTakip\EtkinlikTakip\Views\Activity\Index.cshtml"
               Write(HttpContextAccessor.HttpContext.Session.GetString("userRole"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"';
        console.log(""activity id: "", e.event.id)
        if (role == ""Personel"") {
            e.container.find("".k-scheduler-update"").remove();//kaydet butonunu kaldirir
            e.container.find("".k-scheduler-cancel"").remove();//sil butonunu kaldirir
            e.container.find("".isAllDayAndRuleGroup"").remove();//butun gun kismini kaldirir
            e.container.find("".k-input-button"").remove();//tekrar kismini kaldirir
        }
        else {
            $("".k-edit-buttons"").prepend(""<input value='Davet isteği yolla' type='button' onclick='userDropdown("" + e.event.id + "")' "" +
                ""class='k-button k-button-md k-rounded-md k-button-solid k-button-solid-success'>"");
        }
    }
    function userDropdown(id) {
        $.ajax({
            url: """);
#nullable restore
#line 92 "C:\Users\emret\source\repos\EtkinlikTakip\EtkinlikTakip\Views\Activity\Index.cshtml"
             Write(Url.Action("GetAllUser", "Activity"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@""",
            type: 'POST',
            success: function(users) {
                var model = [{ ""00000000-1111-0000-0000-000000000000"": ""emre"" },
                { ""00000000-1111-1111-0000-000000000000"": ""hasan"" },
                { ""00000000-1111-1111-1111-000000000000"": ""temoçin"" },
                { ""11111111-1111-1111-1111-111111111111"": ""akif"" }];

                Swal.fire({
                    title: 'Lütfen bir davetli seçiniz.',
                    input: 'select',
                    inputOptions: model,
                    inputPlaceholder: 'Davetli seçiniz.',
                    showCancelButton: true,
                    inputValidator: function(value) {
                        return new Promise(function(resolve, reject) {
                            if (value !== '') {
                                resolve();
                            } else {
                                resolve('Lütfen bir kullanıcı seçiniz!');
                            }
                     ");
            WriteLiteral(@"   });
                    }
                }).then(function(result) {
                    if (result.isConfirmed) {
                        InviteRequest(id, result.value)
                    }
                });
            },
            error: function(users) {
            }
        });

    }
    function InviteRequest(id, userId) {
        alert(userId);
        $.ajax({
            url: """);
#nullable restore
#line 129 "C:\Users\emret\source\repos\EtkinlikTakip\EtkinlikTakip\Views\Activity\Index.cshtml"
             Write(Url.Action("InviteRequest", "Activity"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@""",
            type: 'POST',
            data: {
                'activityId': id,
                'invitedUserId': userId
            },
            success: function(response) {
                if (response) {
                    swal({
                        title: 'İşlem Tamam!',
                        text: ""Davet isteği atıldı."",
                        icon: 'success',
                        buttons: {
                            confirm: {
                                text: ""Tamam"",
                                value: true,
                                visible: true,
                                className: """",
                                closeModal: true
                            }
                        }
                    })
                }
                else {
                    swal({
                        title: 'İşlem Yapılmadı!',
                        text: ""Zaten davet isteğinde bulunulmuş."",
                        icon: 'warning',
");
            WriteLiteral(@"                        buttons: {
                            confirm: {
                                text: ""Tamam"",
                                value: true,
                                visible: true,
                                className: """",
                                closeModal: true
                            }
                        }
                    })
                }

            },
            error: function(response) {
                swal({
                    title: 'İşlem Tamamlanamadı!',
                    text: ""Davet isteği yollanırken bir hata ile karşılaşıldı."",
                    icon: 'error',
                    buttons: {
                        confirm: {
                            text: ""Tamam"",
                            value: true,
                            visible: true,
                            className: """",
                            closeModal: true
                        }
                    }
                ");
            WriteLiteral(@"})
            }
        });
    }

    function getFileName() {
        var file = document.getElementById(""inputfile"");
        document.getElementById(""Image"").value = file.files[0].name;
    }
</script>
<script id=""customEventTemplate"" type=""text/x-kendo-template"">
    <div class='movie-template'>
        # if(Image != null){ #
            <img src='/images/#= Image #' style=""max-width:10px; max-height:10px;""/>
        #}#
        <strong>&nbsp#= title #</strong>
        <p>&nbsp#= description #</p>
    </div>
</script>

<script id=""customEditorTemplate"" type=""text/x-kendo-template"">
");
            WriteLiteral(@"    <div class=""k-edit-label""><label for=""title"">Başlık</label></div>
    <div data-container-for=""title"" class=""k-edit-field"">
        <input type=""text"" data-role=""textbox"" name=""title"" required=""required"" data-required-msg=""Lütfen başlığı boş bırakmayınız!"" data-bind=""value:title""/>
    </div>
");
            WriteLiteral(@"    <div class=""k-edit-label"">
        <label for=""start"">Başlangıç</label>
    </div>
    <div data-container-for=""start"" class=""k-edit-field"">
        <input type=""text""
               data-role=""datetimepicker""
               data-interval=""15""
               data-type=""date""
               data-bind=""value:start,invisible:isAllDay""
               validationMessage=""Lütfen geçerli bir tarih giriniz!""
               name=""start""/>
        <input type=""text"" data-type=""date"" data-role=""datepicker"" data-bind=""value:start,visible:isAllDay"" name=""start"" />
        <span data-bind=""text: startTimezone""></span>
        <span data-for=""start"" class=""k-invalid-msg"" style=""display: none;""></span>
    </div>
");
            WriteLiteral(@"    <div class=""k-edit-label""><label for=""end"">Bitiş</label></div>
    <div data-container-for=""end"" class=""k-edit-field"">
        <input type=""text""
               data-type=""date""
               data-role=""datetimepicker""
               data-interval=""15""
               data-bind=""value:end,invisible:isAllDay""
               validationMessage=""Lütfen geçerli bir tarih giriniz!""
               name=""end""
               data-datecompare-msg=""Bitiş tarihi, başlangıç tarihinden büyük veya ona eşit olmalıdır."" />
        <input type=""text"" data-type=""date"" data-role=""datepicker"" data-bind=""value:end,visible:isAllDay"" name=""end"" data-datecompare-msg=""Bitiş tarihi, başlangıç tarihinden büyük veya ona eşit olmalıdır."" />
        <span data-bind=""text: endTimezone""></span>
        <span data-bind=""text: startTimezone, invisible: endTimezone""></span>
        <span data-for=""end"" class=""k-invalid-msg"" style=""display: none;""></span>
      </div>
");
            WriteLiteral(@"    <div class=""isAllDayAndRuleGroup"">
        <div class=""k-edit-label""><label for=""isAllDay"">Bütün gün</label></div>
        <div data-container-for=""isAllDay"" class=""k-edit-field"">
            <input type=""checkbox"" name=""isAllDay"" data-type=""boolean"" data-bind=""checked:isAllDay""/>
        </div>
        <div class=""k-edit-label""><label for=""recurrenceRule"">Tekrar</label></div>
        <div data-container-for=""recurrenceRule"" class=""k-edit-field"">
            <div data-bind=""value:recurrenceRule"" name=""recurrenceRule"" data-role=""recurrenceeditor""></div>
        </div>
    </div>
");
            WriteLiteral(@"    <div class=""k-edit-label""><label for=""description"">Açıklama</label></div>
    <div data-container-for=""description"" class=""k-edit-field"">
        <textarea style=""resize: vertical;"" name=""description"" data-role=""textarea"" data-bind=""value:description""></textarea>
    </div>
");
            WriteLiteral(@"    <div class=""k-edit-label""><label for=""Location"">Lokasyon</label></div>
    <div data-container-for=""Location"" class=""k-edit-field"">
        <input type=""text"" data-role=""textbox"" name=""Location"" required=""required"" data-required-msg=""Lütfen lokasyonu boş bırakmayınız!"" data-bind=""value:Location""/>
    </div>
");
            WriteLiteral(@"    <div class=""k-edit-label""><label for=""MaksKontenjan"">Maksimum Kontenjan</label></div>
    <div data-container-for=""MaksKontenjan"" class=""k-edit-field"">
        <input type=""number""  data-role=""textbox"" name=""MaksKontenjan"" required=""required"" data-required-msg=""Lütfen kontenjanı boş bırakmayınız!"" data-bind=""value:MaksKontenjan""/>
    </div>
");
            WriteLiteral(@"    <div class=""k-edit-label""><label for=""Image"">Fotoğraf</label></div>
        <input id=""inputfile"" name=""inputfile"" onChange=""getFileName()"" type=""file"" accept=""image/*"">
    <div data-container-for=""Image"" class=""k-edit-field"">
        <input type=""text"" data-role=""textbox"" name=""Image"" data-bind=""value:Image"" id=""Image"">
    </div>
</script>

<script id=""activityDetailTemplate"" type=""text/x-kendo-template"">
");
            WriteLiteral("    <div class=\"k-edit-label\"><strong for=\"title\">Başlık</strong></div>\r\n    <div class=\"k-edit-field\"><label style=\"padding: 7px 0px;\" for=\"title\">#= title #</label></div>\r\n");
            WriteLiteral(@"    <div class=""k-edit-label""><strong for=""start"">Başlangıç</strong></div>
    <div data-container-for=""start"" class=""k-edit-field"">
        <input type=""text""
               data-role=""datetimepicker""
               data-interval=""15""
               data-type=""date""
               data-bind=""value:start,invisible:isAllDay""
               validationMessage=""Lütfen geçerli bir tarih giriniz!""
               name=""start"" disabled/>
        <input type=""text"" data-type=""date"" data-role=""datepicker"" data-bind=""value:start,visible:isAllDay"" name=""start"" disabled />
        <span data-bind=""text: startTimezone""></span>
        <span data-for=""start"" class=""k-invalid-msg"" style=""display: none;""></span>
    </div>
");
            WriteLiteral(@"    <div class=""k-edit-label""><strong for=""end"">Bitiş</strong></div>
    <div data-container-for=""end"" class=""k-edit-field"">
        <input type=""text""
               data-type=""date""
               data-role=""datetimepicker""
               data-interval=""15""
               data-bind=""value:end,invisible:isAllDay""
               validationMessage=""Lütfen geçerli bir tarih giriniz!""
               name=""end""
               data-datecompare-msg=""Bitiş tarihi, başlangıç tarihinden büyük veya ona eşit olmalıdır."" disabled/>
        <input type=""text"" data-type=""date"" data-role=""datepicker"" data-bind=""value:end,visible:isAllDay"" name=""end"" data-datecompare-msg=""Bitiş tarihi, başlangıç tarihinden büyük veya ona eşit olmalıdır."" disabled/>
        <span data-bind=""text: endTimezone""></span>
        <span data-bind=""text: startTimezone, invisible: endTimezone""></span>
        <span data-for=""end"" class=""k-invalid-msg"" style=""display: none;""></span>
      </div>
");
            WriteLiteral(@"    <div class=""isAllDayAndRuleGroup"">
        <div class=""k-edit-label""><strong for=""isAllDay"">Bütün gün</strong></div>
        <div data-container-for=""isAllDay"" class=""k-edit-field"">
            <input type=""checkbox"" name=""isAllDay"" data-type=""boolean"" data-bind=""checked:isAllDay""/>
        </div>
        <div class=""k-edit-label""><strong for=""recurrenceRule"">Tekrar</strong></div>
        <div data-container-for=""recurrenceRule"" class=""k-edit-field"">
            <div data-bind=""value:recurrenceRule"" name=""recurrenceRule"" data-role=""recurrenceeditor""></div>
        </div>
    </div>
");
            WriteLiteral(@"    <div class=""k-edit-label""><strong for=""description"">Açıklama</strong></div>
    <div data-container-for=""description"" class=""k-edit-field"">
        <textarea style=""resize: vertical;"" name=""description"" data-role=""textarea"" data-bind=""value:description"" disabled></textarea>
    </div>
");
            WriteLiteral("    <div class=\"k-edit-label\"><strong for=\"Location\">Lokasyon</strong></div>\r\n    <div data-container-for=\"Location\" class=\"k-edit-field\">\r\n        <label style=\"padding: 7px 0px;\" for=\"Location\">#= Location #</label>\r\n    </div>\r\n");
            WriteLiteral(@"    # if(Image != null){ #
        <div class=""k-edit-label""><strong for=""Image"">Fotoğraf</strong></div>
        <div data-container-for=""Image"" class=""k-edit-field"">
            <img src=""/images/#= Image #"" style=""max-width:300px; max-height:150px; min-width:100px; min-height:100px;"" width=""auto"" height=""auto"" >
        </div>
    #}#
</script>");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public IHttpContextAccessor HttpContextAccessor { get; private set; } = default!;
        #nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591