using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;

namespace CnpChallenge.API.Controllers;

[ApiController]
[Route("/api/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class _BaseController : Controller
{ }
