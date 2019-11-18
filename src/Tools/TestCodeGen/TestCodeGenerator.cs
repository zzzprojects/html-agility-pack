using System;
using System.Collections.Generic;
using System.IO;

namespace TestCodeGen
{
    public abstract class TestCodeGenerator
    {
        #region Inner Classes

        public abstract class ParamLoader
        {
            protected TestCodeGenerator Generator { get; private set; }

            public ParamLoader(TestCodeGenerator generator)
            {
                Generator = generator;
            }
            public abstract string Message { get; }
            public abstract void SetUp(string input);
        }

        #endregion

        #region Parameter Loaders

        class OutDirParamLoader : ParamLoader
        {
            public override string Message
                => $"Where do you save the test code? (default: {Generator.OutDir.FullName})";

            public OutDirParamLoader(TestCodeGenerator generator) : base(generator) { }

            public override void SetUp(string input)
            {
                if (!string.IsNullOrEmpty(input))
                    Generator.OutDir = new DirectoryInfo(input);
            }
        }

        class TestNameParamLoader : ParamLoader
        {
            public override string Message
                => "Enter test name";

            public TestNameParamLoader(TestCodeGenerator generator) : base(generator) { }

            public override void SetUp(string input)
            {
                if (string.IsNullOrEmpty(input))
                    throw new ArgumentException("Cannot proceed without a test name.");
                Generator.TestName = input;
            }
        }

        #endregion

        public abstract string MenuItemName { get; }
        protected List<ParamLoader> _paramLoaders { get; }
        public IReadOnlyList<ParamLoader> ParamLoaders => _paramLoaders.AsReadOnly();
        public DirectoryInfo OutDir { get; set; }
        public string TestName { get; private set; }

        public TestCodeGenerator()
        {
            _paramLoaders = new List<ParamLoader>();
            _paramLoaders.Add(new OutDirParamLoader(this));
            _paramLoaders.Add(new TestNameParamLoader(this));
        }
        public abstract IEnumerable<TestCode> Generate();

        public virtual IEnumerable<FileInfo> GenerateAndSaveToFile()
        {
            var testCodes = Generate();

            foreach (var testCode in testCodes)
            {
                if (!testCode.File.Directory.Exists)
                    testCode.File.Directory.Create();
                using (var s = new FileStream(testCode.File.ToString(), FileMode.Create, FileAccess.Write))
                using (var w = new StreamWriter(s))
                {
                    w.WriteLine(testCode.Content);
                }
                yield return testCode.File;
            }
        }
    }
}
