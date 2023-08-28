//*****************************************************************************
// Author: #AUTHOR#
// Copyright: #COMPANYNAME#, #YEAR#
//*****************************************************************************

namespace TemplateFile
{
    using System.Collections;
    using System.Collections.Generic;
    using NUnit.Framework;
    using OnChainStudios.FileTemplates;
    using UnityEngine;
    using UnityEngine.TestTools;

    /// <summary>
    /// [INSERT CLASS COMMENT HERE]
    /// </summary>
    public class TestTemplate
    {
        /// <summary>
        /// A sample test method.
        /// </summary>
        //#UNCOMMENT#[Test]
        public void TestTemplateSimplePasses()
        {
            // Use the Assert class to test conditions
        }

        /// <summary>
        /// A sample test coroutine.
        /// </summary>
        //#UNCOMMENT#[UnityTest]
        public IEnumerator TestTemplateWithEnumeratorPasses()
        {
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            yield return null;
        }
    }
}
