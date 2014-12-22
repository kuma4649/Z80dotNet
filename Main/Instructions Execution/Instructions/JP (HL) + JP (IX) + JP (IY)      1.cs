﻿
// AUTOGENERATED CODE
//
// Do not make changes directly to this (.cs) file.
// Change "JP (HL) + JP (IX) + JP (IY)      .tt" instead.

namespace Konamiman.Z80dotNet
{
    public partial class Z80InstructionExecutor
    {
        /// <summary>
        /// The JP (HL) instruction.
        /// </summary>
        byte JP_aHL()
        {
            FetchFinished();

            Registers.PC = Registers.HL.ToUShort();

            return 4;
        }

        /// <summary>
        /// The JP (IX) instruction.
        /// </summary>
        byte JP_aIX()
        {
            FetchFinished();

            Registers.PC = Registers.IX.ToUShort();

            return 8;
        }

        /// <summary>
        /// The JP (IY) instruction.
        /// </summary>
        byte JP_aIY()
        {
            FetchFinished();

            Registers.PC = Registers.IY.ToUShort();

            return 8;
        }

    }
}
