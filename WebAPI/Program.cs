
using LogicaAccesoDatos;
using LogicaAccesoDatos.Repositorios;
using LogicaAplicacion.CasosDeUso.ImplementacionCasosDeUso.Atletas;
using LogicaAplicacion.CasosDeUso.ImplementacionCasosDeUso.Auditorias;
using LogicaAplicacion.CasosDeUso.ImplementacionCasosDeUso.Disciplinas;
using LogicaAplicacion.CasosDeUso.ImplementacionCasosDeUso.Eventos;
using LogicaAplicacion.CasosDeUso.ImplementacionCasosDeUso.Usuarios;
using LogicaAplicacion.CasosDeUso.InterfacesCasosDeUso.Atletas;
using LogicaAplicacion.CasosDeUso.InterfacesCasosDeUso.Auditorias;
using LogicaAplicacion.CasosDeUso.InterfacesCasosDeUso.Disciplinas;
using LogicaAplicacion.CasosDeUso.InterfacesCasosDeUso.Eventos;
using LogicaAplicacion.CasosDeUso.InterfacesCasosDeUso.Usuarios;
using LogicaNegocio.Entidades;
using LogicaNegocio.InterfacesRepositorio;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddScoped<IRepositorioEvento, RepositorioEvento>();
            builder.Services.AddScoped<IRepositorioDisciplina, RepositorioDisciplina>();
            builder.Services.AddScoped<IRepositorioAtleta, RepositorioAtleta>();
            builder.Services.AddScoped<IRepositorioUsuario, RepositorioUsuario>();
            builder.Services.AddScoped<IRepositorioRol, RepositorioRol>();
            builder.Services.AddScoped<IRepositorioAuditoria, RepositorioAuditoria>();

            builder.Services.AddScoped<IAltaAuditoria, AltaAuditoria>();


            builder.Services.AddScoped<IListadoEventos,ListadoEventos>();
            builder.Services.AddScoped<IBuscarEvento, BuscarEvento>();
            builder.Services.AddScoped<IEventoPorNombre, EventoPorNombre>();
            builder.Services.AddScoped<IEventosPorFecha, EventosPorFecha>();
            builder.Services.AddScoped<IEventoPorPuntaje, EventoPorPuntaje>();


            
            builder.Services.AddScoped<IListadoUsuarios, ListadoUsuarios>();
            builder.Services.AddScoped<ILoginUsuario, LoginUsuario>();


            builder.Services.AddScoped<IListadoDisciplinas, ListadoDisciplinas>();
            builder.Services.AddScoped<IAltaDisciplina, AltaDisciplina>();
            builder.Services.AddScoped<IBuscarDisciplina, BuscarDisciplina>();
            builder.Services.AddScoped<IEditarDisciplina, EditarDisciplina>();
            builder.Services.AddScoped<IEliminarDisciplina, EliminarDisciplina>();
            builder.Services.AddScoped<IDisciplinaPorNombre, DisciplinaPorNombre>();


            builder.Services.AddScoped<IListadoAtletasPorDisciplina, ListadoAtletasPorDisciplina>();
            builder.Services.AddScoped<IListadoAtletas, ListadoAtletas>();



            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            //builder.Services.AddSwaggerGen();
            builder.Services.AddSwaggerGen(options => options.IncludeXmlComments("WebAPI.xml"));


            string cadena = builder.Configuration.GetConnectionString("CadenaConexion");
            builder.Services.AddDbContext<LibreriaContext>(opt => opt.UseSqlServer(cadena));
         

            var claveSecreta = "ZWRpw6fDo28gZW0gY29tcHV0YWRvcmE=";

            builder.Services.AddAuthentication(aut =>
            {
                aut.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                aut.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(aut =>
            {
                aut.RequireHttpsMetadata = false;
                aut.SaveToken = true;
                aut.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.ASCII.GetBytes(claveSecreta)),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            var app = builder.Build();
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
