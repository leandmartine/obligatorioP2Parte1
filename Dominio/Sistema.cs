using Dominio.Entidades;

namespace Dominio
{
    public class Sistema
    {
        private List<Usuario> _usuarios;
        private List<Equipo> _equipos;
        private List<Pago> _pagos;
        private List<Gasto> _gastos;
        private static Sistema s_instancia;


        public Sistema()
        {
            _usuarios = new List<Usuario>();
            _equipos = new List<Equipo>();
            _pagos = new List<Pago>();
            _gastos = new List<Gasto>();
            PrecargarUsuarios();
        }
        public List<Usuario> Usuarios
        {
            get { return new List<Usuario>(_usuarios); }
        }
        public List<Equipo> Equipos
        {
            get { return new List<Equipo>(_equipos); }
        }
        public List<Pago> Pagos
        {
            get { return new List<Pago>(_pagos); }
        }
        public List<Gasto> Gastos
        {
            get { return new List<Gasto>(_gastos); }
        }

        public static Sistema Instancia
        {
            get
            {

                if(s_instancia == null)
                {
                    s_instancia = new Sistema();
                }
                return s_instancia;
            }
        }

        // precarga de datos (4 equipos, 22 usuarios, 10 gastos, 24 pagos recurrentes, 13 pagos unicos), se llama al metodo de alta en cada caso. 
        private void PrecargarUsuarios()
        {
            // ===============================
            // Precarga de Equipos (4 equipos)
            // ===============================
            AltaEquipo(new Equipo("Desarrollo"));
            AltaEquipo(new Equipo("Diseño"));
            AltaEquipo(new Equipo("Marketing"));
            AltaEquipo(new Equipo("Soporte"));

            // ===============================
            // Precarga de Usuarios (22 usuarios). Se llama a los metodos para asignar los objetos de tipo Equipo. 
            // ===============================
            // Equipo 1 → Gerente: Leandro
            AltaUsuario(new Usuario("Leandro", "Martinez", "leandro1234", ObtenerEquipoPorId(1), new DateTime(2023, 5, 15), RolDelUsuario.Gerente));   // leamar@laempresa.com
            AltaUsuario(new Usuario("Renzo", "Rodriguez", "renzo9876", ObtenerEquipoPorId(1), new DateTime(2023, 6, 10), RolDelUsuario.Empleado));  // renrod@laempresa.com
            AltaUsuario(new Usuario("Federico", "Suarez", "federico11", ObtenerEquipoPorId(1), new DateTime(2023, 7, 1), RolDelUsuario.Empleado));  // fedsua@laempresa.com
            AltaUsuario(new Usuario("Bruno", "Lemos", "bruno7890", ObtenerEquipoPorId(1), new DateTime(2023, 12, 5), RolDelUsuario.Empleado));  // brulem@laempresa.com
            AltaUsuario(new Usuario("Julieta", "Cabrera", "julieta55", ObtenerEquipoPorId(1), new DateTime(2023, 1, 5), RolDelUsuario.Empleado));  // julcab@laempresa.com
            AltaUsuario(new Usuario("Nicolas", "Vega", "nicolas33", ObtenerEquipoPorId(1), new DateTime(2023, 7, 23), RolDelUsuario.Empleado));  // nicveg@laempresa.com

            // Equipo 2 → Gerente: Lucía
            AltaUsuario(new Usuario("Lucía", "Fernandez", "lucia4567", ObtenerEquipoPorId(2), new DateTime(2024, 1, 10), RolDelUsuario.Gerente));   // lucfer@laempresa.com
            AltaUsuario(new Usuario("Valentina", "Gomez", "valentina99", ObtenerEquipoPorId(2), new DateTime(2023, 8, 3), RolDelUsuario.Empleado));  // valgom@laempresa.com
            AltaUsuario(new Usuario("Ana", "Torres", "anaTorres1", ObtenerEquipoPorId(2), new DateTime(2022, 10, 17), RolDelUsuario.Empleado));  // anator@laempresa.com
            AltaUsuario(new Usuario("Matias", "Gonzalez", "matias987", ObtenerEquipoPorId(2), new DateTime(2024, 2, 25), RolDelUsuario.Empleado));  // matgon@laempresa.com
            AltaUsuario(new Usuario("Carla", "Pintos", "carla8888", ObtenerEquipoPorId(2), new DateTime(2024, 4, 18), RolDelUsuario.Empleado));  // carpin@laempresa.com
            AltaUsuario(new Usuario("Ezequiel", "Fernandez", "ezequiel5", ObtenerEquipoPorId(2), new DateTime(2023, 10, 1), RolDelUsuario.Empleado));  // ezefer@laempresa.com

            // Equipo 3 → Gerente: Santiago
            AltaUsuario(new Usuario("Santiago", "Perez", "santi2222", ObtenerEquipoPorId(3), new DateTime(2022, 11, 22), RolDelUsuario.Gerente));   // sanper@laempresa.com
            AltaUsuario(new Usuario("Camila", "Ruiz", "camila3333", ObtenerEquipoPorId(3), new DateTime(2023, 2, 14), RolDelUsuario.Empleado));  // camrui@laempresa.com
            AltaUsuario(new Usuario("Florencia", "Mendez", "florencia7", ObtenerEquipoPorId(3), new DateTime(2023, 4, 9), RolDelUsuario.Empleado));  // flomen@laempresa.com
            AltaUsuario(new Usuario("Ignacio", "Silva", "ignacio12", ObtenerEquipoPorId(3), new DateTime(2024, 6, 30), RolDelUsuario.Empleado));  // ignsil@laempresa.com
            AltaUsuario(new Usuario("Agustin", "Costa", "agustin11", ObtenerEquipoPorId(3), new DateTime(2022, 12, 28), RolDelUsuario.Empleado));  // agucos@laempresa.com

            // Equipo 4 → Gerente: Carlos
            AltaUsuario(new Usuario("Carlos", "Lopez", "carlos4444", ObtenerEquipoPorId(4), new DateTime(2024, 3, 8), RolDelUsuario.Gerente));   // carlop@laempresa.com
            AltaUsuario(new Usuario("Mariana", "Diaz", "mariana555", ObtenerEquipoPorId(4), new DateTime(2023, 9, 19), RolDelUsuario.Empleado));  // mardia@laempresa.com
            AltaUsuario(new Usuario("Sofia", "Alvarez", "sofia2025", ObtenerEquipoPorId(4), new DateTime(2023, 3, 20), RolDelUsuario.Empleado));  // sofalv@laempresa.com
            AltaUsuario(new Usuario("Tomas", "Ramos", "tomas9090", ObtenerEquipoPorId(4), new DateTime(2023, 5, 12), RolDelUsuario.Empleado));  // tomram@laempresa.com


            // ===============================
            // Precarga de Gastos (10 gastos)
            // ===============================
            AltaGasto(new Gasto("Afters", "Salidas del equipo"));
            AltaGasto(new Gasto("Electrodomésticos", "Compras para la oficina"));
            AltaGasto(new Gasto("Suministros", "Material de escritorio"));
            AltaGasto(new Gasto("Mantenimiento", "Reparaciones y mantenimiento"));
            AltaGasto(new Gasto("Transporte", "Gastos de movilidad"));
            AltaGasto(new Gasto("Comidas", "Almuerzos y cenas de trabajo"));
            AltaGasto(new Gasto("Software", "Licencias y herramientas digitales"));
            AltaGasto(new Gasto("Capacitación", "Cursos y talleres"));
            AltaGasto(new Gasto("Eventos", "Organización de eventos corporativos"));
            AltaGasto(new Gasto("Marketing", "Publicidad y campañas"));

            // ===============================
            // Pagos Recurrentes (20 activos) pagos con fecha limite posterior a entrega 1. 
            // ===============================
            
            AltaPago(new PagoRecurrente(new DateTime(2024, 12, 28), new DateTime(2025, 12, 28), BuscarGastoPorId(2), MetodoDePago.Efectivo, BuscarUsuarioPorMail("leamar@laempresa.com"), "Pago de nueva heladera", 3000));
            AltaPago(new PagoRecurrente(new DateTime(2024, 11, 15), new DateTime(2025, 11, 15), BuscarGastoPorId(4), MetodoDePago.Debito, BuscarUsuarioPorMail("renrod@laempresa.com"), "Servicio mantenimiento mensual", 1200));
            AltaPago(new PagoRecurrente(new DateTime(2025, 1, 10), new DateTime(2025, 12, 10), BuscarGastoPorId(5), MetodoDePago.Credito, BuscarUsuarioPorMail("lucfer@laempresa.com"), "Combustible para viajes", 800));
            AltaPago(new PagoRecurrente(new DateTime(2024, 10, 20), new DateTime(2025, 10, 20), BuscarGastoPorId(7), MetodoDePago.Credito, BuscarUsuarioPorMail("valgom@laempresa.com"), "Licencia Photoshop", 1500));
            AltaPago(new PagoRecurrente(new DateTime(2024, 12, 28), new DateTime(2025, 9, 28), BuscarGastoPorId(2), MetodoDePago.Efectivo, BuscarUsuarioPorMail("leamar@laempresa.com"), "Pago de nueva cocina eléctrica", 3500));
            AltaPago(new PagoRecurrente(new DateTime(2025, 3, 10), new DateTime(2025, 7, 10), BuscarGastoPorId(9), MetodoDePago.Credito, BuscarUsuarioPorMail("matgon@laempresa.com"), "Suscripción eventos internos", 900));
            AltaPago(new PagoRecurrente(new DateTime(2025, 1, 1), new DateTime(2025, 12, 31), BuscarGastoPorId(6), MetodoDePago.Efectivo, BuscarUsuarioPorMail("flomen@laempresa.com"), "Comidas de equipo", 1800));
            AltaPago(new PagoRecurrente(new DateTime(2024, 5, 20), new DateTime(2025, 5, 20), BuscarGastoPorId(10), MetodoDePago.Credito, BuscarUsuarioPorMail("ignsil@laempresa.com"), "Campañas de marketing mensuales", 2500));
            AltaPago(new PagoRecurrente(new DateTime(2025, 3, 1), new DateTime(2026, 3, 1), BuscarGastoPorId(1), MetodoDePago.Efectivo, BuscarUsuarioPorMail("sofalv@laempresa.com"), "Salidas de integración", 2200));
            AltaPago(new PagoRecurrente(new DateTime(2025, 4, 15), new DateTime(2026, 4, 15), BuscarGastoPorId(8), MetodoDePago.Credito, BuscarUsuarioPorMail("carpin@laempresa.com"), "Pago curso anual de liderazgo", 5000));
            
            // Pagos Recurrentes fijos (sin fecha hasta)
            AltaPago(new PagoRecurrente(new DateTime(2025, 2, 1), DateTime.MinValue, BuscarGastoPorId(7), MetodoDePago.Debito, BuscarUsuarioPorMail("brulem@laempresa.com"), "Pago de cable para TV de oficina", 400));
            AltaPago(new PagoRecurrente(new DateTime(2025, 3, 15), DateTime.MinValue, BuscarGastoPorId(6), MetodoDePago.Efectivo, BuscarUsuarioPorMail("sofalv@laempresa.com"), "Pago de almuerzos semanales del equipo", 1200));
            AltaPago(new PagoRecurrente(new DateTime(2025, 1, 10), DateTime.MinValue, BuscarGastoPorId(2), MetodoDePago.Credito, BuscarUsuarioPorMail("leamar@laempresa.com"), "Compra mensual de insumos eléctricos", 2800));
            AltaPago(new PagoRecurrente(new DateTime(2025, 4, 5), DateTime.MinValue, BuscarGastoPorId(3), MetodoDePago.Debito, BuscarUsuarioPorMail("renrod@laempresa.com"), "Pago de papelería recurrente", 650));
            AltaPago(new PagoRecurrente(new DateTime(2025, 5, 20), DateTime.MinValue, BuscarGastoPorId(8), MetodoDePago.Credito, BuscarUsuarioPorMail("flomen@laempresa.com"), "Suscripción anual de cursos online", 3500));
            AltaPago(new PagoRecurrente(new DateTime(2025, 6, 12), DateTime.MinValue, BuscarGastoPorId(10), MetodoDePago.Efectivo, BuscarUsuarioPorMail("renrod@laempresa.com"), "Campañas de redes sin fecha de fin", 2200));
            AltaPago(new PagoRecurrente(new DateTime(2025, 7, 8), DateTime.MinValue, BuscarGastoPorId(4), MetodoDePago.Debito, BuscarUsuarioPorMail("valgom@laempresa.com"), "Mantenimiento del aire acondicionado", 1300));
            AltaPago(new PagoRecurrente(new DateTime(2025, 8, 15), DateTime.MinValue, BuscarGastoPorId(5), MetodoDePago.Credito, BuscarUsuarioPorMail("ignsil@laempresa.com"), "Gasto de combustible sin fecha de finalización", 950));
            AltaPago(new PagoRecurrente(new DateTime(2025, 9, 25), DateTime.MinValue, BuscarGastoPorId(9), MetodoDePago.Efectivo, BuscarUsuarioPorMail("camrui@laempresa.com"), "Organización de eventos internos sin límite", 1800));
            AltaPago(new PagoRecurrente(new DateTime(2024, 9, 5), DateTime.MinValue, BuscarGastoPorId(8), MetodoDePago.Debito, BuscarUsuarioPorMail("camrui@laempresa.com"), "Curso avanzado de UI/UX", 2000));
            AltaPago(new PagoRecurrente(new DateTime(2025, 2, 1), DateTime.MinValue, BuscarGastoPorId(7), MetodoDePago.Debito, BuscarUsuarioPorMail("brulem@laempresa.com"), "Pago de cable para tv de oficina", 400));



            // ===============================
            // Pagos Recurrentes ya Pagos (5) pagos con fecha anterior a entrega 
            // ===============================
            AltaPago(new PagoRecurrente(new DateTime(2024, 1, 10), new DateTime(2024, 8, 10), BuscarGastoPorId(5), MetodoDePago.Efectivo, BuscarUsuarioPorMail("valgom@laempresa.com"), "Combustible oficina - finalizado", 700));
            AltaPago(new PagoRecurrente(new DateTime(2024, 2, 1), new DateTime(2024, 6, 1), BuscarGastoPorId(7), MetodoDePago.Credito, BuscarUsuarioPorMail("lucfer@laempresa.com"), "Licencia software expirada", 900));
            AltaPago(new PagoRecurrente(new DateTime(2024, 3, 15), new DateTime(2024, 5, 15), BuscarGastoPorId(9), MetodoDePago.Debito, BuscarUsuarioPorMail("renrod@laempresa.com"), "Eventos pasados", 600));
            AltaPago(new PagoRecurrente(new DateTime(2024, 5, 1), new DateTime(2024, 9, 1), BuscarGastoPorId(6), MetodoDePago.Efectivo, BuscarUsuarioPorMail("camrui@laempresa.com"), "Comidas oficina anteriores", 1000));
            AltaPago(new PagoRecurrente(new DateTime(2024, 4, 10), new DateTime(2024, 7, 10), BuscarGastoPorId(2), MetodoDePago.Credito, BuscarUsuarioPorMail("leamar@laempresa.com"), "Pago de impresora - completado", 2500));

            // ===============================
            // Pagos Únicos (17) pagos 
            // ===============================
            AltaPago(new PagoUnico(new DateTime(2025, 05, 20), 1, BuscarGastoPorId(1), MetodoDePago.Efectivo, BuscarUsuarioPorMail("renrod@laempresa.com"), "Salida del equipo 20/05/25", 15000));
            AltaPago(new PagoUnico(new DateTime(2025, 03, 15), 1, BuscarGastoPorId(10), MetodoDePago.Debito, BuscarUsuarioPorMail("renrod@laempresa.com"), "Campaña Marzo", 9000));
            AltaPago(new PagoUnico(new DateTime(2025, 01, 10), 1, BuscarGastoPorId(4), MetodoDePago.Credito, BuscarUsuarioPorMail("valgom@laempresa.com"), "Reparación aire acondicionado", 2500));
            AltaPago(new PagoUnico(new DateTime(2025, 02, 05), 1, BuscarGastoPorId(5), MetodoDePago.Efectivo, BuscarUsuarioPorMail("ignsil@laempresa.com"), "Transporte al evento regional", 1700));
            AltaPago(new PagoUnico(new DateTime(2025, 04, 25), 1, BuscarGastoPorId(8), MetodoDePago.Credito, BuscarUsuarioPorMail("flomen@laempresa.com"), "Curso de liderazgo presencial", 5000));
            AltaPago(new PagoUnico(new DateTime(2024, 12, 10), 1, BuscarGastoPorId(9), MetodoDePago.Efectivo, BuscarUsuarioPorMail("camrui@laempresa.com"), "Evento fin de año", 12000));
            AltaPago(new PagoUnico(new DateTime(2025, 05, 02), 1, BuscarGastoPorId(3), MetodoDePago.Debito, BuscarUsuarioPorMail("brulem@laempresa.com"), "Compra de insumos", 600));
            AltaPago(new PagoUnico(new DateTime(2025, 06, 11), 1, BuscarGastoPorId(7), MetodoDePago.Credito, BuscarUsuarioPorMail("julcab@laempresa.com"), "Nueva licencia software", 4000));
            AltaPago(new PagoUnico(new DateTime(2025, 07, 01), 1, BuscarGastoPorId(6), MetodoDePago.Efectivo, BuscarUsuarioPorMail("sofalv@laempresa.com"), "Cena de equipo trimestral", 3000));
            AltaPago(new PagoUnico(new DateTime(2025, 08, 22), 1, BuscarGastoPorId(10), MetodoDePago.Debito, BuscarUsuarioPorMail("carpin@laempresa.com"), "Publicidad campaña agosto", 11000));
            AltaPago(new PagoUnico(new DateTime(2025, 09, 10), 1, BuscarGastoPorId(2), MetodoDePago.Credito, BuscarUsuarioPorMail("ezefer@laempresa.com"), "Compra de microondas", 2800));
            AltaPago(new PagoUnico(new DateTime(2025, 10, 05), 1, BuscarGastoPorId(1), MetodoDePago.Efectivo, BuscarUsuarioPorMail("leamar@laempresa.com"), "After aniversario", 8500));
            AltaPago(new PagoUnico(new DateTime(2025, 11, 15), 1, BuscarGastoPorId(5), MetodoDePago.Debito, BuscarUsuarioPorMail("agucos@laempresa.com"), "Viaje de trabajo", 7000));
            AltaPago(new PagoUnico(new DateTime(2025, 12, 02), 1, BuscarGastoPorId(4), MetodoDePago.Debito, BuscarUsuarioPorMail("renrod@laempresa.com"), "Reparación de impresora 3D", 3200));
            AltaPago(new PagoUnico(new DateTime(2025, 10, 28), 1, BuscarGastoPorId(8), MetodoDePago.Credito, BuscarUsuarioPorMail("flomen@laempresa.com"), "Pago de curso avanzado en diseño", 4700));
            AltaPago(new PagoUnico(new DateTime(2025, 09, 30), 1, BuscarGastoPorId(2), MetodoDePago.Efectivo, BuscarUsuarioPorMail("leamar@laempresa.com"), "Compra de cafetera para oficina", 2500));
            AltaPago(new PagoUnico(new DateTime(2025, 11, 22), 1, BuscarGastoPorId(10), MetodoDePago.Debito, BuscarUsuarioPorMail("renrod@laempresa.com"), "Campaña publicitaria Black Friday", 12500));
        }
        
        // recibe objeto creado de program o precarga
        public void AltaUsuario(Usuario usu)
        {
            string mailGenerado = usu.GenerarMail();
            string mailValidado = ValidarMail(mailGenerado);
            bool noExisteMail = false;
            while (!noExisteMail)
            {
                if (_usuarios.Contains(usu))
                {
                    mailValidado = ValidarMail(mailGenerado);
                }else
                {
                    noExisteMail = true;
                }
            }
            usu.AgregarMail(mailValidado);
           
            usu.ValidarUsuario();
            _usuarios.Add(usu);
        }
        
        // valida el mail generado por metodo de usuario, si ya existe le crea uno nuevo agregando un numero delante del la ultima letra del apellido
        private string ValidarMail(string mailGenerado)
        {
            string mailProduccion = mailGenerado;
            mailProduccion += "@laempresa.com";
            bool mailCreado = false;
            while (!mailCreado)
            {
                foreach(Usuario Usuario in _usuarios){
                    if (Usuario.Mail == mailProduccion)
                    {
                        mailGenerado += new Random().Next(1,9).ToString();  
                        mailProduccion = mailGenerado;
                        mailProduccion += "@laempresa.com";
                    }
                }            
                mailCreado = true;
            }
            return mailProduccion;
        }

        // recibe un int del id del equipo y devuelve el objeto equipo
        public Equipo ObtenerEquipoPorId(int seleccion)
        {
            foreach (Equipo equipo in _equipos)
            {
                if (equipo.Id == seleccion )
                {
                    return equipo;

                }
            }
            return null;
        }

        // recibe objeto creado de precarga
        public void AltaEquipo(Equipo e)
        {
            if(_equipos.Contains(e)) throw new Exception("El equipo ya existe");
            if(e == null) throw new Exception("El equipo no puede ser nulo");
            e.validarEquipo();
            _equipos.Add(e);
        }

        // recibe objeto creado de precarga
        public void AltaPago(Pago p)
        {
            if (p == null) throw new Exception("El pago no puede ser nulo");
            p.ValidarPago();
            _pagos.Add(p);
        }

        // recibe objeto creado de precarga
        public void AltaGasto(Gasto g)
        {
            if(_gastos.Contains(g)) throw new Exception("El gasto ya existe");
            if (g == null) throw new Exception("El gasto no puede ser nulo");
            g.ValidarGasto();
            _gastos.Add(g);
        }
        
        // recibe un string del mail de un usuario y devuelve el objeto de usuario
        public Usuario BuscarUsuarioPorMail(string mail)
        {
            foreach (Usuario usuario in _usuarios)
            {
                if (usuario.Mail == mail)
                {
                    return usuario;
                }
            }
            return null;
        }
        
        //Busca empleados que no estén eliminados
        public List<Usuario> UsuariosActivos()
        {
            List<Usuario> usuario = new List<Usuario>();
            foreach (Usuario usu in _usuarios)
            {
                if (!usu.Eliminado)
                {
                    usuario.Add(usu);
                }
            }
            return usuario;
        }

        // AGREGAR EN UML
        public void BorrarUsuario(int id)
        {
            foreach (Usuario usu in _usuarios)
            {
                if (usu.Id.Equals(id))
                {
                    usu.EliminarUsuario();
                }
            }
        }
        
        // lista los pagos realizados por el mail ingresado
        public List<Pago> PagosPorMail(string mail)
        {
            List<Pago> pagosUsuario = new List<Pago>();
            Usuario u = BuscarUsuarioPorMail(mail);
            if (u == null)throw new Exception("El mail no es de un usuario registado");
            foreach (Pago pago in _pagos)
            {
                if (pago.Usuario == u)
                {
                    pagosUsuario.Add(pago);
                }
            }
            return pagosUsuario;
        }

        //AGREGAR EN UML
        public List<Pago> PagosDelMes(string mail)
        {
            List<Pago> pagosDelMes = new List<Pago>();

            List<Pago> pagosDelUsuario = PagosPorMail(mail);

            foreach (PagoRecurrente p in pagosDelUsuario)
            {
                if(p.FechaDesde.Month >= DateTime.Now.Month)
                {
                    pagosDelMes.Add(p);
                }
            }
            foreach(PagoUnico pu in pagosDelUsuario)
            {
                if (pu.FechaPago.Month >= DateTime.Now.Month)
                {
                    pagosDelMes.Add(pu);
                }
            }

            return pagosDelMes;
        }

        public List<Pago> PagosOrdenadosXMonto(List<Pago> pagosMes)
        {
            List<Pago> lista = new List<Pago>(pagosMes);
            lista.Sort(new PagosOrdenadosPorMonto());
            return lista;

        }

        // lista los usuarios que pertenecen a un equipo
        public List<Usuario> ListarUsuariosPorEquipo(Equipo e)
        {
            List<Usuario> usuarios = new List<Usuario>();
            foreach (Usuario usuario in _usuarios)
            {
                if (usuario.Equipo == e)
                {
                    usuarios.Add(usuario);
                }
            }
            return usuarios;
        }
        
        // recibe un int del id de un gasto y devuelve el objeto de gasto
        public Gasto BuscarGastoPorId(int id)
        {
            foreach (Gasto gasto in _gastos)
            {
                if (gasto.Id == id)
                {
                    return gasto;
                }
            }
            return null;
        }

        public Usuario Login(string mailUsuario, string passUsuario)
        {
            Usuario usuario = BuscarUsuarioPorMail(mailUsuario);
            if (usuario != null)
            {
                if (usuario.Contrasenha.Equals(passUsuario))
                {
                    return usuario;
                }
                else
                {
                    throw new Exception("Datos Incorrectos, vuelva a intentarlo");
                }
            }
            else
            {
                throw new Exception("Datos Incorrectos, vuelva a intentarlo o crea un usuario");
            }
        }

        // parte de buscar pagos registrados y mostrar los correspondientes al mes acual. Queda para parte 2 del obligatorio
        /*public List<Pago> ListarPagosPorMes()
        {
            List<Pago> p = _pagos;
            foreach (Pago pago in _pagos)
            {
                bool mostrar = pago.MesActualDePago();
                if (mostrar)
                {
                    p.Add(pago);
                }
            }
        }*/

    }

}
