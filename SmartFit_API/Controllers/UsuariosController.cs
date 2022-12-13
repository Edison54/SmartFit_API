using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using P6Shop_API_EdisonChavarriaVasquez;
using SmartFit_API.Models;
using SmartFit_API.Models.DTOs;
using SmartFit_API.Tools;

namespace SmartFit_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   [ApiKey]
    public class UsuariosController : ControllerBase
    {
        private readonly SmartFitContext _context;

        public Tools.Crypto MyCrypto { get; set; }
        public UsuariosController(SmartFitContext context)
        {
            _context = context;
            MyCrypto = new Tools.Crypto();
        }

        // GET: api/Users/GetUserInfo?email=a@gmail.com
        [HttpGet("GetUserInfo")]
        public ActionResult<IEnumerable<UsuarioDTO>> GetUserInfo(string email)
        {
            //las consultas linq se parece a los normales.
            var query = (from u in _context.Usuarios
                         where u.Correo == email 
                         select new
                         {
                             idusuario = u.IdUsuario,
                             nombre = u.Nombre,
                             appelidos = u.Apellidos,
                             rol = u.Rol,
                             direccion = u.Direccion,
                             fechainicio = u.FechaInicio,
                             fechanacimiento = u.FechaNacimiento,
                             telefono = u.Telefono,
                             correo = u.Correo, 
                             password = u.Password



                         }).ToList();
            List<UsuarioDTO> list = new List<UsuarioDTO>();

            foreach (var item in query)
            {
                UsuarioDTO NewItem = new UsuarioDTO();

                NewItem.IdUsuario = item.idusuario;
                NewItem.Nombre = item.nombre;
                NewItem.Apellidos = item.appelidos;
                NewItem.Rol = item.rol;
                NewItem.Direccion = item.direccion;
                NewItem.FechaInicio = item.fechainicio;
                NewItem.FechaNacimiento = item.fechanacimiento;
                NewItem.Telefono = item.telefono;
                NewItem.Correo = item.correo;
                NewItem.Password = item.password;
                list.Add(NewItem);
            }




            if (list == null)
            {
                return NotFound();
            }

            return list;
        }

        // GET: api/Users/GetUserInfo?email=a@gmail.com
        [HttpGet("GetUserEmail")]
        public ActionResult<IEnumerable<UsuarioDTO>> GetUserEmail (string email)
        {
            //las consultas linq se parece a los normales.
            var query = (from u in _context.Usuarios
                         where u.Correo == email
                         select new
                         {
                             idusuario = u.IdUsuario,
                             nombre = u.Nombre,
                             appelidos = u.Apellidos,
                             rol = u.Rol,
                             direccion = u.Direccion,
                             fechainicio = u.FechaInicio,
                             fechanacimiento = u.FechaNacimiento,
                             telefono = u.Telefono,
                             correo = u.Correo,
                             password = u.Password



                         }).ToList();
            List<UsuarioDTO> list = new List<UsuarioDTO>();

            foreach (var item in query)
            {
                UsuarioDTO NewItem = new UsuarioDTO();

                NewItem.IdUsuario = item.idusuario;
                NewItem.Nombre = item.nombre;
                NewItem.Apellidos = item.appelidos;
                NewItem.Rol = item.rol;
                NewItem.Direccion = item.direccion;
                NewItem.FechaInicio = item.fechainicio;
                NewItem.FechaNacimiento = item.fechanacimiento;
                NewItem.Telefono = item.telefono;
                NewItem.Correo = item.correo;
                NewItem.Password = item.password;
                list.Add(NewItem);
            }




           
            bool isEmpty = !list.Any();
            if (isEmpty)
            {
                return NotFound();
            }

            return list;
        }




        // GET: api/Usuarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarios()
        {
            return await _context.Usuarios.ToListAsync();
        }

        // GET: api/Usuarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> GetUsuario(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);

            if (usuario == null)
            {
                return NotFound();
            }

            return usuario;
        }
         
      


        // GET: api/Users/5
        [HttpGet("ValidateLogin")]
        public async Task<ActionResult<Usuario>> ValidateLogin(string UserName, string UserPassword)
        {
            string ApiLevelEncriptedPassword = MyCrypto.EncriptarEnUnSentido(UserPassword);

            var user = await _context.Usuarios.SingleOrDefaultAsync(e => e.Correo == UserName && e.Password == ApiLevelEncriptedPassword);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }



        // PUT: api/Usuarios/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuario(int id, Usuario usuario)
        {
            if (id != usuario.IdUsuario)
            {
                return BadRequest();
            }

            _context.Entry(usuario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Usuarios
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Usuario>> PostUsuario(Usuario usuario)
        {

            string ApiLevelEncriptedPass = MyCrypto.EncriptarEnUnSentido(usuario.Password);
            usuario.Password = ApiLevelEncriptedPass;
        

            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUsuario", new { id = usuario.IdUsuario }, usuario);
        }

        // DELETE: api/Usuarios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuario(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }

            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UsuarioExists(int id)
        {
            return _context.Usuarios.Any(e => e.IdUsuario == id);
        }
    }
}
