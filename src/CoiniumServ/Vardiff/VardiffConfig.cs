﻿#region License
// 
//     CoiniumServ - Crypto Currency Mining Pool Server Software
//     Copyright (C) 2013 - 2014, CoiniumServ Project - http://www.coinium.org
//     http://www.coiniumserv.com - https://github.com/CoiniumServ/CoiniumServ
// 
//     This software is dual-licensed: you can redistribute it and/or modify
//     it under the terms of the GNU General Public License as published by
//     the Free Software Foundation, either version 3 of the License, or
//     (at your option) any later version.
// 
//     This program is distributed in the hope that it will be useful,
//     but WITHOUT ANY WARRANTY; without even the implied warranty of
//     MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//     GNU General Public License for more details.
//    
//     For the terms of this license, see licenses/gpl_v3.txt.
// 
//     Alternatively, you can license this software under a commercial
//     license or white-label it as set out in licenses/commercial.txt.
// 
#endregion
using System;
using Serilog;

namespace CoiniumServ.Vardiff
{
    public class VardiffConfig:IVardiffConfig
    {
        public bool Enabled { get; private set; }
        public float MinimumDifficulty { get; private set; }
        public float MaximumDifficulty { get; private set; }
        public int TargetTime { get; private set; }
        public int RetargetTime { get; private set; }
        public int VariancePercent { get; private set; }
        public bool Valid { get; private set; }

        public VardiffConfig(dynamic config)
        {
            try
            {
                // load the config data.
                Enabled = config.enabled;
                MinimumDifficulty = config.minDiff == 0 ? 8: (float)config.minDiff;
                MaximumDifficulty = config.maxDiff == 0 ? 512 : (float)config.maxDiff;
                TargetTime = config.targetTime == 0 ? 15 : config.targetTime;
                RetargetTime = config.retargetTime == 0 ? 90 : config.retargetTime;
                VariancePercent = config.variancePercent == 0 ? 30 : config.variancePercent;

                Valid = true;
            }
            catch (Exception e)
            {
                Valid = false;
                Log.Logger.ForContext<VardiffConfig>().Error(e, "Error loading vardiff configuration");
            }   
        }
    }
}
