﻿using System;
using System.Collections.Generic;

namespace Konamiman.Z80dotNet
{
    public partial class Z80InstructionExecutor
    {
        private IDictionary<byte, Func<byte>> DD_InstructionExecutors;

        private void Initialize_DD_InstructionsTable()
        {
            DD_InstructionExecutors = new Dictionary<byte, Func<byte>>
            {
                { 0x09, ADD_IX_BC },
                { 0x19, ADD_IX_DE },
                { 0x21, LD_IX_nn },
                { 0x22, LD_aa_IX },
                { 0x23, INC_IX },
                { 0x24, INC_IXH },
                { 0x25, DEC_IXH },
                { 0x26, LD_IXH_n },
                { 0x29, ADD_IX_IX },
                { 0x2A, LD_IX_aa },
                { 0x2B, DEC_IX },
                { 0x2C, INC_IXL },
                { 0x2D, DEC_IXL },
                { 0x2E, LD_IXL_n },
                { 0x34, INC_aIX_plus_n },
                { 0x35, DEC_aIX_plus_n },
                { 0x36, LD_aIX_plus_n_N },
                { 0x39, ADD_IX_SP },
                { 0x44, LD_B_IXH },
                { 0x45, LD_B_IXL },
                { 0x46, LD_B_aIX_plus_n },
                { 0x4C, LD_C_IXH },
                { 0x4D, LD_C_IXL },
                { 0x4E, LD_C_aIX_plus_n },
                { 0x54, LD_D_IXH },
                { 0x55, LD_D_IXL },
                { 0x56, LD_D_aIX_plus_n },
                { 0x5C, LD_E_IXH },
                { 0x5D, LD_E_IXL },
                { 0x5E, LD_E_aIX_plus_n },
                { 0x60, LD_IXH_B },
                { 0x61, LD_IXH_C },
                { 0x62, LD_IXH_D },
                { 0x63, LD_IXH_E },
                { 0x64, LD_IXH_IXH },
                { 0x65, LD_IXH_IXL },
                { 0x66, LD_H_aIX_plus_n },
                { 0x67, LD_IXH_A },
                { 0x68, LD_IXL_B },
                { 0x69, LD_IXL_C },
                { 0x6A, LD_IXL_D },
                { 0x6B, LD_IXL_E },
                { 0x6C, LD_IXL_H },
                { 0x6D, LD_IXL_IXL },
                { 0x6E, LD_L_aIX_plus_n },
                { 0x6F, LD_IXL_A },
                { 0x70, LD_aIX_plus_n_B },
                { 0x71, LD_aIX_plus_n_C },
                { 0x72, LD_aIX_plus_n_D },
                { 0x73, LD_aIX_plus_n_E },
                { 0x74, LD_aIX_plus_n_H },
                { 0x75, LD_aIX_plus_n_L },
                { 0x77, LD_aIX_plus_n_A },
                { 0x7C, LD_A_IXH },
                { 0x7D, LD_A_IXL },
                { 0x7E, LD_A_aIX_plus_n },
                { 0x84, ADD_A_IXH },
                { 0x85, ADD_A_IXL },
                { 0x86, ADD_A_aIX_plus_n },
                { 0x8C, ADC_A_IXH },
                { 0x8D, ADC_A_IXL },
                { 0x8E, ADC_A_aIX_plus_n },
                { 0x94, SUB_IXH },
                { 0x95, SUB_IXL },
                { 0x96, SUB_aIX_plus_n },
                { 0x9C, SBC_A_IXH },
                { 0x9D, SBC_A_IXL },
                { 0x9E, SBC_A_aIX_plus_n },
                { 0xA4, AND_IXH },
                { 0xA5, AND_IXL },
                { 0xA6, AND_aIX_plus_n },
                { 0xAC, XOR_IXH },
                { 0xAD, XOR_IXL },
                { 0xAE, XOR_aIX_plus_n },
                { 0xB4, OR_IXH },
                { 0xB5, OR_IXL },
                { 0xB6, OR_aIX_plus_n },
                { 0xBC, CP_IXH },
                { 0xBD, CP_IXL },
                { 0xBE, CP_aIX_plus_n },
                { 0xE1, POP_IX },
                { 0xE3, EX_aSP_IX },
                { 0xE5, PUSH_IX },
                { 0xE9, JP_aIX },
                { 0xF9, LD_SP_IX },
            };
        }

        //TODO: Move instructions to their own files when they are implemented.

        /// <summary>
        /// The LD SP,IX instruction.
        /// </summary>
        byte LD_SP_IX()
        {
            throw new NotImplementedException();
        }
    }
}
