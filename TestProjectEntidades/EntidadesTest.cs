using System;
using Entidades;
using Entidades.Enumerados;

namespace TestProjectEntidades
{
    [TestClass]
    public class EntidadesTest
    {
        //Pruebo que los contructores de Windows inicialicen bien los atributos por defecto
        [TestMethod]
        public void ConsturctorSin2ParametrosWindows()
        {

            //Sin nombre ni virtualizacion como parametros
            Windows windows = new Windows("1,3", 4.5, EEstadoSoporte.SoporteLimitado, EEdicionWindows.Enterprise);
            bool validacion_nombre = windows.Nombre == "Windows";
            bool validacion_virtualizacion = windows.VirtualizacionPermitida == false;

            Assert.IsTrue(validacion_nombre && validacion_virtualizacion);
        }

        [TestMethod]
        public void ConsturctorSinNombreWindows()
        {
            //sin nombre como parametro
            Windows windows = new Windows("1,3", 4.5, EEstadoSoporte.SoporteLimitado, EEdicionWindows.Enterprise, true);
            bool validacion_nombre = windows.Nombre == "Windows";
            Assert.IsTrue(validacion_nombre);
        }

        [TestMethod]
        public void ConsturctorSinVirtualizacionWindows()
        {
            //sin virtualizacion como parametro
            Windows windows = new Windows("Windows", "1,3", 4.5, EEstadoSoporte.SoporteLimitado, EEdicionWindows.Enterprise);
            bool validacion_virtualizacion = windows.VirtualizacionPermitida == false;
            Assert.IsTrue(validacion_virtualizacion);
        }

        //Pruebo que los contructores de MacOS inicialicen bien los atributos por defecto
        [TestMethod]
        public void ConstructorSinIcloudMacOS()
        {
            //Constructor sin Icloud como parametro
            MacOS mac = new MacOS("Big Sur", "2.5", 5.5, true, EEstadoSoporte.SinSoporte);
            bool validacion_icloud = mac.IntegracionIcloud == false;
            Assert.IsTrue(validacion_icloud);
        }
        [TestMethod]
        public void ConstructorSinCompatibleAppleMacOS()
        {
            //Constructor sin compatibleApple como parametro
            MacOS mac = new MacOS("Big Sur", "2.5", 5.5, EEstadoSoporte.SinSoporte,true);
            bool validacion_compatible = mac.CompatibleConProcesadorApple == false;
            Assert.IsTrue(validacion_compatible);
        }
        [TestMethod]
        public void ConstructorSin2ParametrosMacOS()
        {
            //Constructor sin compatibleApple ni integracionIcloud como parametro
            MacOS mac = new MacOS("Big Sur", "2.5", 5.5, EEstadoSoporte.SinSoporte);
            bool validacion_compatible = mac.CompatibleConProcesadorApple == false;
            bool validacion_icloud = mac.IntegracionIcloud == false;
            Assert.IsTrue(validacion_compatible && validacion_icloud);
        }
        //Pruebo los construcotres de Linux
        [TestMethod]
        public void ConstructorsinNombreLinux()
        {
            //Constructor sin nombre como parametro
            Linux linux = new Linux("3.3", 4.4, EEstadoSoporte.SoporteCompleto, EDistribucionLinux.Ubuntu, true);
            bool validacion_nombre = linux.Nombre == "Linux";
            Assert.IsTrue(validacion_nombre);
        }
        [TestMethod]
        public void ConstructorsinInterfazLinux()
        {
            //Constructor sin interfaz como parametro
            Linux linux = new Linux("Linux","3.3", 4.4, EEstadoSoporte.SoporteCompleto, EDistribucionLinux.Ubuntu);
            bool validacion_interfaz = linux.InterfazGrafica == false;
            Assert.IsTrue(validacion_interfaz);
        }
        [TestMethod]
        public void Constructorsin2ParametrosfazLinux()
        {
            //Constructor sin interfaz ni nombre como parametro
            Linux linux = new Linux("3.3", 4.4, EEstadoSoporte.SoporteCompleto, EDistribucionLinux.Ubuntu);
            bool validacion_interfaz = linux.InterfazGrafica == false;
            bool validacion_nombre = linux.Nombre == "Linux";

            Assert.IsTrue(validacion_interfaz &&validacion_nombre);
        }
    }
}