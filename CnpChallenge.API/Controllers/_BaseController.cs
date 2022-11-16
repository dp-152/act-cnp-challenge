using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;

namespace CnpChallenge.API.Controllers;

[ApiController]
[ApiVersion("1")]
[Route("/api/v{version:apiVersion}/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class _BaseController : Controller
{ }
