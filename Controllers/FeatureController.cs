using FeatureManagement.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.FeatureManagement;
using Microsoft.FeatureManagement.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeatureManagement.Controllers
{
    [Route("api/[controller]")]
    [FeatureGate(FeatureFlags.FeatureAll)]
    public class FeatureController : ControllerBase
    {
        public FeatureController(IFeatureManager featureManager)
        {
            FeatureManager = featureManager;
        }
        public IFeatureManager FeatureManager { get; set; }
        public string Result { get; private set; }

        [HttpGet]
        public async Task<ActionResult> GetAsync()
        {
            if (await FeatureManager.IsEnabledAsync(feature: "Feature1"))
            {
                Result = Feature1();
            }
            else
            if (await FeatureManager.IsEnabledAsync(feature: "Feature2"))
            {
                Result = Feature2();
            }
            else
            if (await FeatureManager.IsEnabledAsync(feature: "Feature3"))
            {
                Result = Feature3();
            }
            else
            {
                Result = Feature4();
            }
            return Ok(Result);

        }
        #region
        [ApiExplorerSettings(IgnoreApi = true)]
        public string Feature1()
        {
            return "Call Feature1";
        }
        [ApiExplorerSettings(IgnoreApi = true)]

        public string Feature2()
        {
            return "Call Feature2";
        }
        [ApiExplorerSettings(IgnoreApi = true)]

        public string Feature3()
        {
            return "Call Feature3";
        }
        [ApiExplorerSettings(IgnoreApi = true)]

        public string Feature4()
        {
            return "Call Feature4";
        }
        #endregion
    }
}
