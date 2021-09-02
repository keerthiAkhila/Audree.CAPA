using Audree.CAPA.Application.DTO_s.Masters;
using Audree.CAPA.Core.Contracts.IRepositories;
using Audree.CAPA.Core.Models.Masters;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Audree.CAPA.API.Controllers.Masters
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        #region Private fields  
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;
        #endregion
        public StudentController(IStudentRepository studentrepository, IMapper mapper)
        {
            _studentRepository = studentrepository;
            _mapper = mapper;
        }
        #region GETALL
        /// <summary>
        /// Purpose     : TO GetALL Details
        /// Created By  : Audree Infotech Pvt. Ltd.
        /// Created On :  31-08-2021
        /// Employee Id: 100299
        /// </summary>
        /// <param name="StudentController"></param>
        /// <returns></returns>
        // GET api/<controller>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _studentRepository.GetAllStudentdetails());
        }
        #endregion
        #region CreateUpdate
        /// <summary>
        /// Purpose : To CreateOrUpdate 
        /// Created By : Audree Infotech Pvt. Ltd.
        /// Created On : 31-08-21
        /// Employee Id: 100299
        /// <param name="StudentDto"></param>
        /// <returns></returns>
        // POST api/<controller>
        [HttpPost("CreateorUpdate")]
        public async Task<IActionResult> CreateorUpdate([FromBody] StudentDTO studentDto)
        {
            return Ok(await _studentRepository.CreateOrUpdate(_mapper.Map<Student>(studentDto)));
        }
        #endregion
    }
}