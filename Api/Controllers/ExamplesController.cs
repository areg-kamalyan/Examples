using Api.Models;
using AutoMapper;
using Core;
using Core.Entitys;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExamplesController : ControllerBase
    {
        private readonly IMapper _mapper;
        public ExamplesController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet("AutoMapStudentToEmployer")]
        //[Authorize]
        public List<Employer> AutoMapStudentToEmployer()
        {
            var student = Generator.Generate<Student>(5);
            return _mapper.Map<List<Employer>>(student);
        }
    }
}
