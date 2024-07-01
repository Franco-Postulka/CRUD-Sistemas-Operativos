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
            Windows windows = new Windows("11", 4.5, EEstadoSoporte.SoporteLimitado, EEdicionWindows.Enterprise);
            bool validacion_nombre = windows.Nombre == "Windows";
            bool validacion_virtualizacion = windows.VirtualizacionPermitida == false;

            Assert.IsTrue(validacion_nombre && validacion_virtualizacion);
        }

        [TestMethod]
        public void ConsturctorSinNombreWindows()
        {
            //sin nombre como parametro
            Windows windows = new Windows("11", 4.5, EEstadoSoporte.SoporteLimitado, EEdicionWindows.Enterprise, true);
            bool validacion_nombre = windows.Nombre == "Windows";
            Assert.IsTrue(validacion_nombre);
        }

        [TestMethod]
        public void ConsturctorSinVirtualizacionWindows()
        {
            //sin virtualizacion como parametro
            Windows windows = new Windows("Windows", "11", 4.5, EEstadoSoporte.SoporteLimitado, EEdicionWindows.Enterprise);
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



        ///Compqracion de objetos

        [TestMethod]
        public void EqualsMacOS()
        {
            //Dos mac con mismo nombre y version deben ser iguales.
            MacOS mac = new MacOS("Big Sur", "2.5", 5.5, EEstadoSoporte.SinSoporte, true);
            MacOS mac2 = new MacOS("Big Sur", "2.5", 2.5, EEstadoSoporte.SoporteCompleto, false);

            bool comparacion = mac.Equals(mac2);

            Assert.IsTrue(comparacion);
        }

        [TestMethod]
        public void NoEqualsMacOS()
        {
            //Dos mac con distinto nombre o version son distintos.
            MacOS mac = new MacOS("Big Sur", "2.5", 5.5, EEstadoSoporte.SinSoporte, true);
            MacOS mac2 = new MacOS("Sonoma", "2.5", 5.5, EEstadoSoporte.SinSoporte, true);

            bool comparacionversion = mac.Equals(mac2);

            MacOS mac3 = new MacOS("Big Sur", "2.5", 5.5, EEstadoSoporte.SinSoporte, true);
            MacOS mac4 = new MacOS("Big Sur", "2.5", 5.5, EEstadoSoporte.SinSoporte, true);

            bool comparacionnombre = mac3.Equals(mac4);

            Assert.IsTrue(!(comparacionversion && comparacionversion));
        }

        [TestMethod]
        public void EqualsWindows()
        {
            //Dos Windows con misma edicion y version deben ser iguales.
            Windows windows = new Windows("Windows","10", 4.5, EEstadoSoporte.SoporteLimitado, EEdicionWindows.Enterprise);
            Windows windows2 = new Windows("Windows","10", 6.25, EEstadoSoporte.SoporteCompleto, EEdicionWindows.Enterprise);

            bool comparacion = windows.Equals(windows2);

            Assert.IsTrue(comparacion);
        }

        [TestMethod]
        public void NoEqualsWindows()
        {
            //Dos Windows con distinta edicion y version son distintos.
            Windows windows = new Windows("Windows", "10", 4.5, EEstadoSoporte.SoporteLimitado, EEdicionWindows.Enterprise);
            Windows windows2 = new Windows("Windows", "11", 6.25, EEstadoSoporte.SoporteCompleto, EEdicionWindows.Enterprise);

            bool comparacion_version = windows.Equals(windows2);

            Assert.IsTrue(!comparacion_version);

            Windows windows3 = new Windows("Windows", "10", 4.5, EEstadoSoporte.SoporteLimitado, EEdicionWindows.Enterprise);
            Windows windows4 = new Windows("Windows", "10", 6.25, EEstadoSoporte.SoporteCompleto, EEdicionWindows.Pro);

            bool comparacion_edicion = windows3.Equals(windows4);

            Assert.IsTrue(!(comparacion_version && comparacion_edicion));
        }

        public void EqualsLinux()
        {
            //Dos Linux con misma distribucion y version deben ser iguales.
            Linux linux = new Linux("Linux", "3.3", 4.4, EEstadoSoporte.SoporteCompleto, EDistribucionLinux.Ubuntu);
            Linux linux2 = new Linux("Linux", "3.3", 4.4, EEstadoSoporte.SoporteLimitado, EDistribucionLinux.Ubuntu);

            bool comparacion = linux.Equals(linux2);

            Assert.IsTrue(comparacion);
        }

        [TestMethod]
        public void NoEqualsLinux()
        {
            //Dos Linux con distinta distribucion y version son distintos.
            Linux linux = new Linux("Linux", "3.3", 4.4, EEstadoSoporte.SoporteCompleto, EDistribucionLinux.Ubuntu);
            Linux linux2 = new Linux("Linux", "3.3", 4.4, EEstadoSoporte.SoporteLimitado, EDistribucionLinux.CentOS);

            bool comparacion_distribucion = linux.Equals(linux2);

            Linux linux3 = new Linux("Linux", "3.3", 4.4, EEstadoSoporte.SoporteCompleto, EDistribucionLinux.CentOS);
            Linux linux4 = new Linux("Linux", "1.1", 4.4, EEstadoSoporte.SoporteLimitado, EDistribucionLinux.CentOS);

            bool comparacion_version = linux3.Equals(linux4);

            Assert.IsTrue(!(comparacion_distribucion && comparacion_version));
        }


    }
}