using System;
using System.Runtime.InteropServices;
using UnityEngine;

public class FakeAssertion
{
    [DllImport("user32.dll", CharSet = CharSet.Unicode)]
    private static extern int MessageBoxW(
        IntPtr hWnd,
        string lpText,
        string lpCaption,
        uint uType);

    [ContextMenu("Show Fake Assertion")]
    public void ShowFakeAssertion()
    {
        string text =
        @"Debug Assertion Failed!

        Program:
            File: C:\..\VC\Tools\MSVC\14.38.33130\include\vector
            Line: 3195

        Expression: vector<bool> subscript out of range

        For information on how your program can cause an assertion
        failure, see the Visual C++ documentation on asserts.


        I'm kidding.
        ";

        const uint MB_OK = 0x00000000;
        const uint MB_ICONERROR = 0x00000010;

        MessageBoxW(
            IntPtr.Zero,
            text,
            "Microsoft Visual C++ Runtime Library",
            MB_OK | MB_ICONERROR);
    }
}