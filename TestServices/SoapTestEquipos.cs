using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestServices
{
    [TestClass]
    public class SoapTestEquipos
    {
        [TestMethod]
        public void TestObtenerEquipoOK()
        {
            WCFEquipos.EquiposClient proxy = new WCFEquipos.EquiposClient();
            WCFEquipos.SHMC_EQUI obtenerEquipo = proxy.ObtenerEquipo(1);

            Assert.AreEqual("abc", obtenerEquipo.ALF_SERI);
            Assert.AreEqual(1, obtenerEquipo.COD_ESTA);
            Assert.AreEqual(1, obtenerEquipo.COD_TIPO_UBIC);
            Assert.AreEqual(1, obtenerEquipo.COD_ALMA);
            Assert.AreEqual(1, obtenerEquipo.COD_TECN);
            Assert.AreEqual(1, obtenerEquipo.COD_PUNT_ATEN);
        }

        [TestMethod]
        public void TestModificarEquipoOK()
        {
            WCFEquipos.EquiposClient proxy = new WCFEquipos.EquiposClient();
            WCFEquipos.SHMC_EQUI equipoAModificar = proxy.ModificarEquipo(new WCFEquipos.SHMC_EQUI()
            {
                COD_EQUI = 1,
                ALF_SERI = "def",
                COD_ESTA = 1,
                COD_TIPO_UBIC = 1,
                COD_ALMA = 1,
                COD_TECN = 1,
                COD_PUNT_ATEN = 1
            });
            Assert.AreEqual(1, equipoAModificar.COD_EQUI);
            Assert.AreEqual("def", equipoAModificar.ALF_SERI);
            Assert.AreEqual(1, equipoAModificar.COD_ESTA);
            Assert.AreEqual(1, equipoAModificar.COD_TIPO_UBIC);
            Assert.AreEqual(1, equipoAModificar.COD_ALMA);
            Assert.AreEqual(1, equipoAModificar.COD_TECN);
            Assert.AreEqual(1, equipoAModificar.COD_PUNT_ATEN);
        }

        [TestMethod]
        public void TestListarEquiposOK()
        {
            WCFEquipos.EquiposClient proxy = new WCFEquipos.EquiposClient();
            WCFEquipos.SHMC_EQUI[] equiposEncontrados = proxy.ListarEquipos(1);

            Assert.AreEqual(1, equiposEncontrados[0].COD_EQUI);
            Assert.AreEqual("def", equiposEncontrados[0].ALF_SERI);
            Assert.AreEqual(1, equiposEncontrados[0].COD_ESTA);
            Assert.AreEqual(1, equiposEncontrados[0].COD_TIPO_UBIC);
            Assert.AreEqual(1, equiposEncontrados[0].COD_ALMA);
            Assert.AreEqual(1, equiposEncontrados[0].COD_TECN);
            Assert.AreEqual(1, equiposEncontrados[0].COD_PUNT_ATEN);
        }
    }
}
