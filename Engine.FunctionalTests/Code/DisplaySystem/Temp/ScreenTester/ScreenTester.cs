﻿using System;

namespace Engine.FunctionalTests.DisplaySystem
{
    public class ScreenTester
    {
        #region Methods
        public void Run()
        {
            DisplayRequestPanelsNumber();
            var panelsNumber = RequestPanelsNumber();

            //new PanelsCreator().CreateRandomPanels(panelsNumber);
            //InputSystem.Get.SetState(State.Testing);
            //InputSystem.Get.Run();
            //ClearConsole();

            //DisplayControlHelp(panelsNumber);
        }
        #endregion

        #region Properties
        public State State { get; private set; } = State.Initial;
        #endregion

        #region DisplayMessages
        private void DisplayRequestPanelsNumber()
        {
            Data.Messages.ConfirmInputHint.Write(after: "\n");
            Data.Messages.DeleteCharHint.Write(after: "\n\n");
            Data.Messages.RequestPanelsNumber.Write();
        }

        private void DisplayControlHelp(int panelsNumber)
        {
            Data.Messages.PanelsNumber(panelsNumber).Write(after: "\n\n");

            for (int i = 0; i < panelsNumber; i++)
            {
                foreach (var message in Data.Messages.KeyInfo(Data.Panels.KeysFor.DisplayOnScreen[i]))
                    message.Write();

                Data.Messages.DisplayPanel(i).Write(after: "\n");
            }

            Data.Messages.Empty.Write(after: "\n");

            for (int i = 0; i < panelsNumber; i++)
            {
                foreach (var message in Data.Messages.KeyInfo(Data.Panels.KeysFor.HideFromScreen[i]))
                    message.Write();

                Data.Messages.HidePanel(i).Write(after: "\n");
            }

            //Data.Messages.Key("F1").Write(before: "\n");
            //Data.Messages.DisplayHelp.Write(before: " - ", after: "\n");

            //Data.Messages.Key("Enter").Write();
            //Data.Messages.StartTesting.Write(before: " - ", after: "\n");

            //Data.Messages.Key("Escape").Write();
            //Data.Messages.ProgramExit.Write(before: " - ", after: "\n");
        }
        #endregion

        #region PrivateMethods
        private int RequestPanelsNumber()
        {
            Console.CursorVisible = true;
            string input = Console.ReadLine();

            if (Services.CheckNumberInput(input, Data.Panels.Min, Data.Panels.Max, out int panelsNumber) is false)
            {
                Data.Messages.WrongInput.Write();
                var cursorPosition = Console.GetCursorPosition();

                do
                {
                    var length = input is not null ? input.Length : 1;
                    Services.InConsole.ClearLinePart(cursorPosition, length + 1);
                    input = Console.ReadLine();
                }
                while (Services.CheckNumberInput(input, Data.Panels.Min, Data.Panels.Max, out panelsNumber) is false);
            }

            Console.CursorVisible = false;
            return panelsNumber;
        }
        #endregion
    }
}