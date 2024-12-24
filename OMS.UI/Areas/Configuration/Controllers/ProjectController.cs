using Microsoft.AspNetCore.Mvc;
using OMS.UI.Areas.Configuration.ViewModels;

namespace OMS.UI.Areas.Configuration.Controllers;
[Area("Configuration")]
public class ProjectController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public ProjectController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    public async Task<IActionResult> Index()
    {
        return View();
    }
    public async Task<IActionResult> Project()
    {
        // Page Title
        ViewData["pTitle"] = "Projects Profile";

        // Breadcrumb
        ViewData["bGParent"] = "Configuration";
        ViewData["bParent"] = "Project";
        ViewData["bChild"] = "Project";

        var client = _httpClientFactory.CreateClient("ApiGatewayCall");

        var projectSettings = await client.GetFromJsonAsync<List<ProjectSettingVM>>("ProjectSetting/GetAll");
        var projectStatusSettings = await client.GetFromJsonAsync<List<ProjectStatusVM>>("ProjectStatus/GetAll");
        var projectCategories = await client.GetFromJsonAsync<List<ProjectCategoryVM>>("ProjectCategory/GetAll");
        var viewModel = new ProjectVM
        {
            ProjectSettingVM = projectSettings,
            ProjectStatusVM = projectStatusSettings,
            ProjectCategoryVM = projectCategories
        };
        return View(viewModel);
    }


    [HttpPost]
    public async Task<IActionResult> ProjectSettingUpdate(ProjectSettingVM projSetting)
    {
        if (projSetting.Id == 0) return View();
        var client = _httpClientFactory.CreateClient("ApiGatewayCall");
        await client.PutAsJsonAsync<ProjectSettingVM>("ProjectSetting/Update/", projSetting);
        return RedirectToAction("Project");
    }

    [HttpPost]
    public async Task<IActionResult> DefaultStatusUpdate(int Id)
    {
        if (Id == 0) return View();
        var client = _httpClientFactory.CreateClient("ApiGatewayCall");
        await client.PutAsJsonAsync("ProjectStatus/UpdateDefaultStatus?Id=", Id);
        return RedirectToAction("Project");
    }


    [HttpGet]
    public async Task<IActionResult> EditProjectStatus(int Id)
    {
        if (Id == 0) return View();
        var client = _httpClientFactory.CreateClient("ApiGatewayCall");
        var projectStatus = await client.GetFromJsonAsync<ProjectStatusVM>("ProjectStatus/GetById/?Id=" + Id);
        return PartialView("_Edit", projectStatus);
    }

    [HttpPost]
    public async Task<IActionResult> UpdateProjectStatus(ProjectStatusVM projectStatus)
    {
        if (projectStatus.Id == 0) return View();
        var client = _httpClientFactory.CreateClient("ApiGatewayCall");
        await client.PutAsJsonAsync<ProjectStatusVM>("ProjectStatus/Update/", projectStatus);
        return RedirectToAction("Project");
    }


    [HttpPost]
    public async Task<IActionResult> Delete(int Id)
    {
        if (Id == 0) return View();
        var client = _httpClientFactory.CreateClient("ApiGatewayCall");
        await client.DeleteAsync("ProjectStatus/Delete?Id=" + Id);
        return RedirectToAction("Project");
    }


    //[HttpGet]
    //public async Task<IActionResult> Create()
    //{
    //    RoleVM role = new();
    //    var client = _httpClientFactory.CreateClient("ApiGatewayCall");
    //    var companies = await client.GetFromJsonAsync<List<CompanyVM>>("Company/GetAll");
    //    var departments = await client.GetFromJsonAsync<List<DepartmentVM>>("Department/GetAll");
    //    var designations = await client.GetFromJsonAsync<List<DesignationVM>>("Designation/GetAll");
    //    ViewBag.CompanyList = companies;
    //    ViewBag.DepartmentList = departments;
    //    ViewBag.DesignationList = designations;
    //    return PartialView("_Create", role);
    //}

    //[HttpPost]
    //public async Task<IActionResult> Create(RoleVM role)
    //{
    //    var client = _httpClientFactory.CreateClient("ApiGatewayCall");
    //    await client.PostAsJsonAsync<RoleVM>("Role/Create", role);
    //    return RedirectToAction("Role");
    //}

    //[HttpGet]
    //public async Task<IActionResult> Edit(int Id)
    //{
    //    if (Id == 0) return View();
    //    var client = _httpClientFactory.CreateClient("ApiGatewayCall");
    //    var companies = await client.GetFromJsonAsync<List<CompanyVM>>("Company/GetAll");
    //    var departments = await client.GetFromJsonAsync<List<DepartmentVM>>("Department/GetAll");
    //    var designations = await client.GetFromJsonAsync<List<DesignationVM>>("Designation/GetAll");
    //    ViewBag.CompanyList = companies;
    //    ViewBag.DepartmentList = departments;
    //    ViewBag.DesignationList = designations;
    //    var role = await client.GetFromJsonAsync<RoleVM>("Role/GetById/?Id=" + Id);
    //    return PartialView("_Edit", role);
    //}

    //[HttpPost]
    //public async Task<IActionResult> Update(RoleVM role)
    //{
    //    if (role.Id == 0) return View();
    //    var client = _httpClientFactory.CreateClient("ApiGatewayCall");
    //    await client.PutAsJsonAsync<RoleVM>("Role/Update/", role);
    //    return RedirectToAction("Role");
    //}

    //[HttpGet]
    //public async Task<IActionResult> Delete(int Id)
    //{
    //    if (Id == 0) return View();
    //    var client = _httpClientFactory.CreateClient("ApiGatewayCall");
    //    var companies = await client.GetFromJsonAsync<List<CompanyVM>>("Company/GetAll");
    //    var departments = await client.GetFromJsonAsync<List<DepartmentVM>>("Department/GetAll");
    //    var designations = await client.GetFromJsonAsync<List<DesignationVM>>("Designation/GetAll");
    //    ViewBag.CompanyList = companies;
    //    ViewBag.DepartmentList = departments;
    //    ViewBag.DesignationList = designations;
    //    var role = await client.GetFromJsonAsync<RoleVM>("Role/GetById/?Id=" + Id);
    //    return PartialView("_Delete", role);
    //}

    //[HttpPost]
    //public async Task<IActionResult> Delete(RoleVM role)
    //{
    //    if (role.Id == 0) return View();
    //    var client = _httpClientFactory.CreateClient("ApiGatewayCall");
    //    await client.DeleteAsync("Role/Delete?Id=" + role.Id);
    //    return RedirectToAction("Role");
    //}

    //[HttpPost]
    //public async Task<IActionResult> Delete(RoleVM role)
    //{
    //    JsonSerializerOptions options = new(JsonSerializerDefaults.Web)
    //    {
    //        WriteIndented = true
    //    };
    //    string forecastJson = JsonSerializer.Serialize<RoleVM>(role, options);

    //    if (role.Id == 0) return View();
    //    var client = _httpClientFactory.CreateClient("ApiGatewayCall");
    //    var roleList = Deletewithresponse(client.BaseAddress.AbsoluteUri + "Role/Delete", role);
    //    return RedirectToAction("Role");
    //}

    //public async Task<HttpResponseMessage> Deletewithresponse(string url, object entity)
    //{
    //    using (var client = new HttpClient())
    //    {
    //        var json = JsonSerializer.Serialize(entity);
    //        var content = new StringContent(json, Encoding.UTF8, "application/json");

    //        var request = new HttpRequestMessage
    //        {
    //            Method = HttpMethod.Delete,
    //            RequestUri = new Uri(url),
    //            Content = content
    //        };
    //        return await client.SendAsync(request);
    //    }
    //}
}