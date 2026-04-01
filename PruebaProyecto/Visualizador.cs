using PruebaProyecto.Productos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PruebaProyecto.Bases;
using PruebaProyecto.Fabricas;
using PruebaProyecto.Decoradores;

namespace PruebaProyecto
{
    public class Visualizador
    {
        private Orden _orden;
        private Ventas _ventas;
        private AdministradorMesa _administradorMesa;
        private Inventario _inventario;
        private CreadorFormato _creadorFormato;
        private string _dec;
        private bool _bucle;

        private FabricaAlimento _fab;

        public Visualizador()
        {
            _ventas = new Ventas();
            _administradorMesa = AdministradorMesa.obtenerInstancia();
            _inventario = new Inventario();

            _bucle = true;

            BucleMenu();
        }

        public void BucleMenu()
        {
            do
            {
                try
                {
                    Console.Clear();

                    Console.WriteLine("=================== GESTIÓN DE RESTAURANTE ===================");
                    Console.WriteLine($"+ Mesas disponibles: {_administradorMesa.ContarMesasDisponibles()}");
                    Console.WriteLine("========================== OPCIONES ==========================");
                    Console.WriteLine("1. Revisar estado de mesas");
                    Console.WriteLine("2. Ocupar mesa disponible");
                    Console.WriteLine("3. Desocupar mesa");
                    Console.WriteLine("4. Registrar una orden");
                    Console.WriteLine("5. Consultar ventas y propinas");
                    Console.WriteLine("6. Desplegar inventario");
                    Console.WriteLine("7. Reponer ingredientes necesarios");
                    Console.WriteLine("8. Finalizar operaciones por el día");
                    Console.WriteLine("9. Salir del programa");
                    Console.Write("Seleccione una opción a realizar: ");
                    _dec = Console.ReadLine().ToLower();

                    switch (_dec)
                    {
                        case "1":
                        case "revisar":
                            Console.WriteLine();
                            _administradorMesa.MostrarMesas();
                            break;
                        case "2":
                        case "ocupar":
                            _administradorMesa.OcuparMesa();
                            break;
                        case "3":
                        case "desocupar":
                            _administradorMesa.MostrarMesas();
                            Console.Write("Ingrese el número de mesa a ocupar: ");
                            int i = int.Parse(Console.ReadLine());
                            _administradorMesa.DesocuparMesa(i);
                            break;
                        case "4":
                        case "registrar":
                            Console.Clear();
                            MenuOrden();
                            break;
                        case "5":
                        case "consultar":
                            Console.Clear();
                            _ventas.MostrarVentas();
                            break;
                        case "6":
                        case "desplegar":
                            _inventario.DesplegarInventario();
                            break;
                        case "7":
                        case "reponer":
                            _inventario.ReponerInventario();
                            break;
                        case "8":
                        case "finalizar":
                            Console.Write("¿Desea finalizar las operaciones? s/n: ");
                            _dec = Console.ReadLine().ToLower();
                            if (_dec == "s") { FinalizarJornada(); }
                            break;
                        case "9":
                        case "salir":
                            Console.Write("¿Desea salir del programa? s/n: ");
                            _dec = Console.ReadLine().ToLower();
                            if(_dec == "s")
                            {
                                Console.WriteLine("Entendido, cerrando el programa...");
                                _bucle = false;
                                Thread.Sleep(500);
                            }
                            break;
                        default:
                            Console.WriteLine("Comando desconocido. Intente ingresar el número o la primera palabra del comando a realizar.");
                            break;
                    }
                }
                
                catch(Exception ex) 
                {
                    Console.WriteLine($"Error: {ex}");
                    Console.WriteLine("Intente de nuevo.");
                }
                Console.ReadKey();
            } while (_bucle == true);
        }
        public void MenuOrden()
        {
            _orden = new Orden();
            bool bucleMenu = true;

            do
            {
                Console.WriteLine("====================== TIPO DE ALIMENTO ======================");
                Console.WriteLine("1. Platillo");
                Console.WriteLine("2. Bebida");
                Console.Write("Seleccione una opción: ");

                _dec = Console.ReadLine().ToLower();

                switch (_dec)
                {
                    case "1":
                    case "platillo":
                        MenuSecundarioPlatillos();
                        break;
                    case "2":
                    case "bebida":
                        MenuSecundarioBebidas();
                        break;
                    default:
                        Console.WriteLine("Opción inválida, intente de nuevo.");
                        break;
                }
                
                Console.Write("¿Desea agregar otro elemento? s/n: ");
                _dec = Console.ReadLine();
                
                if (_dec.ToLower() != "s")
                {
                    bucleMenu = false;
                }
                
                Console.Clear();

            } while (bucleMenu == true);

            if (ComprobarOrden(_orden.ListaBebidas) && ComprobarOrden(_orden.ListaPlatillos))
            {
                Console.WriteLine("Orden registrada con éxito");
                _ventas.AgregarVenta(_orden);
            }
        }
        public void MenuSecundarioPlatillos()
        {
            Console.WriteLine("========================= DISPONIBLES ========================");
            Console.WriteLine("1. Enchiladas");
            Console.WriteLine("2. Flautas");
            Console.WriteLine("3. Tostadas");
            Console.WriteLine("4. Carne asada");
            Console.WriteLine("5. Sopes");
            Console.Write("Seleccione una opción: ");
            _dec = Console.ReadLine().ToLower();
            switch (_dec)
            {
                case "1":
                case "enchiladas":
                    //_fab = new FabricaEnchiladas();
                    //Alimento enchiladas = _fab.CrearAlimento();
                    //_orden.AgregarPlatillo(enchiladas);
                    ManejarPlatillo(_fab = new FabricaEnchiladas());
                    break;
                case "2":
                case "flautas":
                    ManejarPlatillo(_fab = new FabricaFlautas());
                    break;
                case "3":
                case "tostadas":
                    ManejarPlatillo(_fab = new FabricaTostadas());
                    break;
                case "4":
                case "carne asada":
                    ManejarPlatillo(_fab = new FabricaCarneAsada());
                    break;
                case "5":
                case "sopes":
                    ManejarPlatillo(_fab = new FabricaSopes());
                    break;
                default:
                    Console.WriteLine("Opción inválida, intente de nuevo");
                    break;
            }
        }
        public void MenuSecundarioBebidas()
        {
            Console.WriteLine("========================= DISPONIBLES ========================");
            Console.WriteLine("1. Limonada");
            Console.WriteLine("2. Agua de jamaica");
            Console.WriteLine("3. Horchata");
            Console.WriteLine("4. Lata de refresco");
            Console.WriteLine("5. Agua");
            Console.Write("Seleccione una opción: ");
            _dec = Console.ReadLine().ToLower();
            switch (_dec)
            {
                case "1":
                case "limonada":
                    ManejarBebida(_fab = new FabricaLimonada());
                    break;
                case "2":
                case "agua de jamaica":
                case "jamaica":
                    ManejarBebida(_fab = new FabricaJamaica());
                    break;
                case "3":
                case "horchata":
                    ManejarBebida(_fab = new FabricaHorchata());
                    break;
                case "4":
                case "lata de refresco":
                case "refresco":
                    ManejarBebida(_fab = new FabricaRefresco());
                    break;
                case "5":
                case "agua":
                    ManejarBebida(_fab = new FabricaAgua());
                    break;
                default:
                    Console.WriteLine("Opción inválida, intente de nuevo");
                    break;
            }
        }
        public bool ComprobarOrden(List<Alimento> lista)
        {
            foreach (var elemento in lista)
            {
                if (_inventario.UtilizarIngredientes(elemento))
                {
                    Console.WriteLine("Alimento ordenado exitosamente");
                }
                else
                {
                    Console.WriteLine("Intente ordenar otra cosa.");
                    return false;
                }
            }
            return true;
        }
        public void ManejarPlatillo(FabricaAlimento fab)
        {
            Alimento pla = fab.CrearAlimento();
            _orden.AgregarPlatillo(pla);
        }
        public void ManejarBebida(FabricaAlimento fab)
        {
            Alimento beb = fab.CrearAlimento();
            _orden.AgregarBebida(beb);
        }
        public void FinalizarJornada()
        {
            List<string> reporte = new List<string>();
            _creadorFormato = new TXT();

            Console.Clear();
            _ventas.MostrarVentas();

            _creadorFormato.AgregarLinea("=========================== VENTAS ===========================");
            _creadorFormato.AgregarLinea($"Fecha: {DateTime.Now.ToString("U")}");
            _creadorFormato.CapturarLineas(()=>_ventas.MostrarVentas());

            foreach(var ingrediente in _inventario.Ingredientes)
            {
                if(ingrediente.Cantidad <= ingrediente.PuntoDeOrden)
                {
                    string mensaje = $"* Se recomienda ordenar más {ingrediente.Nombre} *";
                    Console.WriteLine(mensaje);
                    _creadorFormato.AgregarLinea(mensaje);
                }
            }

            Console.Write("¿Desea elaborar el reporte en XML? s/n: ");
            _dec = Console.ReadLine().ToLower();
            if (_dec == "s") { _creadorFormato = new FormatoXML(_creadorFormato); }

            Console.Write("¿Desea elaborar el reporte en PDF? s/n: ");
            _dec = Console.ReadLine().ToLower();
            if(_dec == "s") { _creadorFormato = new FormatoPDF(_creadorFormato); }
            
            _creadorFormato.CrearFormato();

            _creadorFormato.Reiniciar();
            _ventas.Reiniciar();

            Console.ReadKey();
        }
    }
}
