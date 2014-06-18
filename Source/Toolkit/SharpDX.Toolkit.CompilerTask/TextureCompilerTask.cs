﻿// Copyright (c) 2010-2014 SharpDX - Alexandre Mutel
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

using System.IO;

using SharpDX.Toolkit.Diagnostics;
using SharpDX.Toolkit.Graphics;

namespace SharpDX.Toolkit
{
    public class TextureCompilerTask : ContentCompilerTask
    {
        protected override Diagnostics.Logger ProcessFileAndGetLogResults(string inputFilePath, string outputFilePath, string dependencyFilePath, TkItem item)
        {
            // the textures can be in a subdirectory - make sure it exists before copying there:
            CreateDirectoryIfNotExists(outputFilePath);

            // For the TextureCompilerTask, simply copy input to output without performing any resize/compression
            // but a future version will introduce this
            File.Copy(inputFilePath, outputFilePath, true);

            // Save the dependency file
            var dependencies = new FileDependencyList();
            dependencies.AddDefaultDependencies();
            dependencies.AddDependencyPath(inputFilePath);
            dependencies.Save(dependencyFilePath);

            return new Logger();
        }
    }
}