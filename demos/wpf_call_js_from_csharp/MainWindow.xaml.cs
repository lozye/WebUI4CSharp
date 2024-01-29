﻿using System.Windows;
using WebUI4CSharp;

namespace wpf_call_js_from_csharp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public void my_function_exit(WebUIEvent e)
        {
            // Close all opened windows
            WebUI.Exit();
        }

        public void my_function_count(WebUIEvent e)
        {
            // This function gets called every time the user clicks on "MyButton1"
            WebUIWindow? window = e.Window;

            if (window != null)
            {
                string response;

                if (!window.Script("return GetCount();", 0, out response, 64))
                {
                    if (!window.IsShown())
                    {
                        Console.WriteLine("Window closed.");
                    }
                    else
                    {
                        Console.WriteLine("JavaScript Error: %s", response);
                    }
                    return;
                }

                // Get the count
                int count = Convert.ToInt32(response);

                // Increment
                count++;

                // Generate a JavaScript
                string js = $"SetCount({count});";

                // Run JavaScript
                window.Run(js);
            }
        }

        private void Window_OnWebUIEvent(object? sender, BindEventArgs e)
        {
            if (e.BindEvent.Element == "MyButton1")
            {
                my_function_count(e.BindEvent);
            }
            else if (e.BindEvent.Element == "MyButton2")
            {
                my_function_exit(e.BindEvent);
            }
        }

        private void ShowBrowserBtn_Click(object sender, RoutedEventArgs e)
        {
            if (WebUI.IsAppRunning()) { return; }

            string my_html = "<!DOCTYPE html>" +
                                      "<html>" +
                                      "  <head>" +
                                      "    <meta charset=\"UTF-8\">" +
                                      "    <script src=\"webui.js\"></script>" +
                                      "    <title>Call JavaScript from C Example</title>" +
                                      "    <style>" +
                                      "       body {" +
                                      "            font-family: 'Arial', sans-serif;" +
                                      "            color: white;" +
                                      "            background: linear-gradient(to right, #507d91, #1c596f, #022737);" +
                                      "            text-align: center;" +
                                      "            font-size: 18px;" +
                                      "        }" +
                                      "        button, input {" +
                                      "            padding: 10px;" +
                                      "            margin: 10px;" +
                                      "            border-radius: 3px;" +
                                      "            border: 1px solid #ccc;" +
                                      "            box-shadow: 0 3px 5px rgba(0,0,0,0.1);" +
                                      "            transition: 0.2s;" +
                                      "        }" +
                                      "        button {" +
                                      "            background: #3498db;" +
                                      "            color: #fff; " +
                                      "            cursor: pointer;" +
                                      "            font-size: 16px;" +
                                      "        }" +
                                      "        h1 { text-shadow: -7px 10px 7px rgb(67 57 57 / 76%); }" +
                                      "        button:hover { background: #c9913d; }" +
                                      "        input:focus { outline: none; border-color: #3498db; }" +
                                      "    </style>" +
                                      "  </head>" +
                                      "  <body>" +
                                      "    <h1>WebUI - Call JavaScript from C</h1>" +
                                      "    <br>" +
                                      "    <h1 id=\"count\">0</h1>" +
                                      "    <br>" +
                                      "    <button id=\"MyButton1\">Manual Count</button>" +
                                      "    <br>" +
                                      "    <button id=\"MyTest\" OnClick=\"AutoTest();\">Auto Count (Every 500ms)</button>" +
                                      "    <br>" +
                                      "    <button id=\"MyButton2\">Exit</button>" +
                                      "    <script>" +
                                      "      let count = 0;" +
                                      "      function GetCount() {" +
                                      "        return count;" +
                                      "      }" +
                                      "      function SetCount(number) {" +
                                      "        document.getElementById('count').innerHTML = number;" +
                                      "        count = number;" +
                                      "      }" +
                                      "      function AutoTest(number) {" +
                                      "        setInterval(function(){ webui.call('MyButton1'); }, 500);" +
                                      "      }" +
                                      "    </script>" +
                                      "  </body>" +
                                      "</html>";

            WebUIWindow window = new WebUIWindow();
            window.Bind("MyButton1");
            window.Bind("MyButton2");
            window.OnWebUIEvent += Window_OnWebUIEvent;
            window.Show(my_html);
        }
    }
}
