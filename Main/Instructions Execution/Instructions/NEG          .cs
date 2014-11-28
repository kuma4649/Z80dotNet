﻿namespace Konamiman.Z80dotNet
{
    public partial class Z80InstructionExecutor
    {
        /// <summary>
        /// The NEG instruction.
        /// </summary>
        byte NEG()
        {
            FetchFinished();

            var oldValue = Registers.A;
            var newValue = (byte)((byte)0).Sub(oldValue);
            Registers.A = newValue;

            Registers.SF = newValue.GetBit(7);
            Registers.ZF = (newValue == 0);
            Registers.HF = (oldValue != 0);
            Registers.PF = (oldValue == 0x80);
            Registers.NF = 1;
            Registers.CF = (oldValue != 0);
            SetFlags3and5From(newValue);

            return 8;
        }
    }
}
