using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Linq;
using Crestron;
using Crestron.Logos.SplusLibrary;
using Crestron.Logos.SplusObjects;
using Crestron.SimplSharp;

namespace CrestronModule_EVNTSKED
{
    public class CrestronModuleClass_EVNTSKED : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        Crestron.Logos.SplusObjects.DigitalInput ENABLE;
        Crestron.Logos.SplusObjects.DigitalInput HOUR_UP;
        Crestron.Logos.SplusObjects.DigitalInput HOUR_DOWN;
        Crestron.Logos.SplusObjects.DigitalInput MINUTE_UP;
        Crestron.Logos.SplusObjects.DigitalInput MINUTE_DOWN;
        Crestron.Logos.SplusObjects.DigitalInput NOW;
        Crestron.Logos.SplusObjects.DigitalInput DAY_UP;
        Crestron.Logos.SplusObjects.DigitalInput DAY_DOWN;
        Crestron.Logos.SplusObjects.DigitalInput MONTH_UP;
        Crestron.Logos.SplusObjects.DigitalInput MONTH_DOWN;
        Crestron.Logos.SplusObjects.DigitalInput YEAR_UP;
        Crestron.Logos.SplusObjects.DigitalInput YEAR_DOWN;
        Crestron.Logos.SplusObjects.DigitalInput TODAY;
        Crestron.Logos.SplusObjects.DigitalInput REPEAT_VALUE_UP;
        Crestron.Logos.SplusObjects.DigitalInput REPEAT_VALUE_DOWN;
        Crestron.Logos.SplusObjects.AnalogInput EVENT_NUM;
        Crestron.Logos.SplusObjects.AnalogInput NUM_EVENTS;
        Crestron.Logos.SplusObjects.AnalogInput REPEAT_TYPE;
        Crestron.Logos.SplusObjects.DigitalOutput EVENT_TRIG;
        Crestron.Logos.SplusObjects.AnalogOutput EVENT_DUE;
        Crestron.Logos.SplusObjects.StringOutput EVENT_TYPE__DOLLAR__;
        Crestron.Logos.SplusObjects.StringOutput EVENT_DATE__DOLLAR__;
        Crestron.Logos.SplusObjects.StringOutput EVENT_TIME__DOLLAR__;
        Crestron.Logos.SplusObjects.StringOutput MESSAGE__DOLLAR__;
        private void GETDAYOFWEEK (  SplusExecutionContext __context__ ) 
            { 
            
            __context__.SourceCodeLine = 88;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( _SplusNVRAM.EVENTMONTH < 3 ))  ) ) 
                { 
                __context__.SourceCodeLine = 89;
                _SplusNVRAM.ZELLERYEAR = (ushort) ( (_SplusNVRAM.EVENTYEAR - 1) ) ; 
                __context__.SourceCodeLine = 90;
                _SplusNVRAM.ZELLERMONTH = (ushort) ( (_SplusNVRAM.EVENTMONTH + 10) ) ; 
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 93;
                _SplusNVRAM.ZELLERYEAR = (ushort) ( _SplusNVRAM.EVENTYEAR ) ; 
                __context__.SourceCodeLine = 94;
                _SplusNVRAM.ZELLERMONTH = (ushort) ( (_SplusNVRAM.EVENTMONTH - 2) ) ; 
                } 
            
            __context__.SourceCodeLine = 96;
            _SplusNVRAM.ZELLERCENTURY = (ushort) ( (_SplusNVRAM.ZELLERYEAR / 100) ) ; 
            __context__.SourceCodeLine = 97;
            _SplusNVRAM.ZELLERYEAR = (ushort) ( Mod( _SplusNVRAM.ZELLERYEAR , 100 ) ) ; 
            __context__.SourceCodeLine = 99;
            _SplusNVRAM.DAYOFWEEK = (ushort) ( Mod( ((((((((26 * _SplusNVRAM.ZELLERMONTH) - 2) / 10) + _SplusNVRAM.EVENTDAY) + _SplusNVRAM.ZELLERYEAR) + (_SplusNVRAM.ZELLERYEAR / 4)) + (_SplusNVRAM.ZELLERCENTURY / 4)) - (2 * _SplusNVRAM.ZELLERCENTURY)) , 7 ) ) ; 
            __context__.SourceCodeLine = 102;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( _SplusNVRAM.DAYOFWEEK < 0 ))  ) ) 
                {
                __context__.SourceCodeLine = 103;
                _SplusNVRAM.DAYOFWEEK = (ushort) ( (_SplusNVRAM.DAYOFWEEK + 7) ) ; 
                }
            
            __context__.SourceCodeLine = 105;
            
                {
                int __SPLS_TMPVAR__SWTCH_1__ = ((int)_SplusNVRAM.DAYOFWEEK);
                
                    { 
                    if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 0) ) ) ) 
                        { 
                        __context__.SourceCodeLine = 107;
                        _SplusNVRAM.DAYOFWEEK__DOLLAR__  .UpdateValue ( "Sunday"  ) ; 
                        } 
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 1) ) ) ) 
                        { 
                        __context__.SourceCodeLine = 109;
                        _SplusNVRAM.DAYOFWEEK__DOLLAR__  .UpdateValue ( "Monday"  ) ; 
                        } 
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 2) ) ) ) 
                        { 
                        __context__.SourceCodeLine = 111;
                        _SplusNVRAM.DAYOFWEEK__DOLLAR__  .UpdateValue ( "Tuesday"  ) ; 
                        } 
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 3) ) ) ) 
                        { 
                        __context__.SourceCodeLine = 113;
                        _SplusNVRAM.DAYOFWEEK__DOLLAR__  .UpdateValue ( "Wednesday"  ) ; 
                        } 
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 4) ) ) ) 
                        { 
                        __context__.SourceCodeLine = 115;
                        _SplusNVRAM.DAYOFWEEK__DOLLAR__  .UpdateValue ( "Thursday"  ) ; 
                        } 
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 5) ) ) ) 
                        { 
                        __context__.SourceCodeLine = 117;
                        _SplusNVRAM.DAYOFWEEK__DOLLAR__  .UpdateValue ( "Friday"  ) ; 
                        } 
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 6) ) ) ) 
                        { 
                        __context__.SourceCodeLine = 119;
                        _SplusNVRAM.DAYOFWEEK__DOLLAR__  .UpdateValue ( "Saturday"  ) ; 
                        } 
                    
                    } 
                    
                }
                
            
            
            }
            
        private void GETJDAY (  SplusExecutionContext __context__ ) 
            { 
            
            __context__.SourceCodeLine = 132;
            _SplusNVRAM.PRVYEAR = (ushort) ( (_SplusNVRAM.TEMPYEAR - 1) ) ; 
            __context__.SourceCodeLine = 133;
            _SplusNVRAM.LEAPS = (ushort) ( ((((_SplusNVRAM.PRVYEAR / 4) - (_SplusNVRAM.PRVYEAR / 100)) + (_SplusNVRAM.PRVYEAR / 400)) - 484) ) ; 
            __context__.SourceCodeLine = 136;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (Mod( _SplusNVRAM.TEMPYEAR , 4 ) == 0) ) && Functions.TestForTrue ( Functions.BoolToInt (Mod( _SplusNVRAM.TEMPYEAR , 100 ) != 0) )) ) ) || Functions.TestForTrue ( Functions.BoolToInt (Mod( _SplusNVRAM.TEMPYEAR , 400 ) == 0) )) ))  ) ) 
                {
                __context__.SourceCodeLine = 137;
                _SplusNVRAM.LEAPYEAR = (ushort) ( 1 ) ; 
                }
            
            else 
                {
                __context__.SourceCodeLine = 139;
                _SplusNVRAM.LEAPYEAR = (ushort) ( 0 ) ; 
                }
            
            __context__.SourceCodeLine = 141;
            
                {
                int __SPLS_TMPVAR__SWTCH_2__ = ((int)_SplusNVRAM.TEMPMONTH);
                
                    { 
                    if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_2__ == ( 1) ) ) ) 
                        {
                        __context__.SourceCodeLine = 144;
                        _SplusNVRAM.JDAY = (ushort) ( _SplusNVRAM.TEMPDAY ) ; 
                        }
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_2__ == ( 2) ) ) ) 
                        { 
                        __context__.SourceCodeLine = 146;
                        _SplusNVRAM.TEMPDAY = (ushort) ( Functions.Min( _SplusNVRAM.TEMPDAY , (28 + _SplusNVRAM.LEAPYEAR) ) ) ; 
                        __context__.SourceCodeLine = 147;
                        _SplusNVRAM.JDAY = (ushort) ( (_SplusNVRAM.TEMPDAY + 31) ) ; 
                        } 
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_2__ == ( 3) ) ) ) 
                        {
                        __context__.SourceCodeLine = 150;
                        _SplusNVRAM.JDAY = (ushort) ( (_SplusNVRAM.TEMPDAY + 59) ) ; 
                        }
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_2__ == ( 4) ) ) ) 
                        { 
                        __context__.SourceCodeLine = 152;
                        _SplusNVRAM.TEMPDAY = (ushort) ( Functions.Min( _SplusNVRAM.TEMPDAY , 30 ) ) ; 
                        __context__.SourceCodeLine = 153;
                        _SplusNVRAM.JDAY = (ushort) ( (_SplusNVRAM.TEMPDAY + 90) ) ; 
                        } 
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_2__ == ( 5) ) ) ) 
                        {
                        __context__.SourceCodeLine = 156;
                        _SplusNVRAM.JDAY = (ushort) ( (_SplusNVRAM.TEMPDAY + 120) ) ; 
                        }
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_2__ == ( 6) ) ) ) 
                        { 
                        __context__.SourceCodeLine = 158;
                        _SplusNVRAM.TEMPDAY = (ushort) ( Functions.Min( _SplusNVRAM.TEMPDAY , 30 ) ) ; 
                        __context__.SourceCodeLine = 159;
                        _SplusNVRAM.JDAY = (ushort) ( (_SplusNVRAM.TEMPDAY + 151) ) ; 
                        } 
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_2__ == ( 7) ) ) ) 
                        {
                        __context__.SourceCodeLine = 162;
                        _SplusNVRAM.JDAY = (ushort) ( (_SplusNVRAM.TEMPDAY + 181) ) ; 
                        }
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_2__ == ( 8) ) ) ) 
                        {
                        __context__.SourceCodeLine = 164;
                        _SplusNVRAM.JDAY = (ushort) ( (_SplusNVRAM.TEMPDAY + 212) ) ; 
                        }
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_2__ == ( 9) ) ) ) 
                        { 
                        __context__.SourceCodeLine = 166;
                        _SplusNVRAM.TEMPDAY = (ushort) ( Functions.Min( _SplusNVRAM.TEMPDAY , 30 ) ) ; 
                        __context__.SourceCodeLine = 167;
                        _SplusNVRAM.JDAY = (ushort) ( (_SplusNVRAM.TEMPDAY + 243) ) ; 
                        } 
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_2__ == ( 10) ) ) ) 
                        {
                        __context__.SourceCodeLine = 170;
                        _SplusNVRAM.JDAY = (ushort) ( (_SplusNVRAM.TEMPDAY + 273) ) ; 
                        }
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_2__ == ( 11) ) ) ) 
                        { 
                        __context__.SourceCodeLine = 172;
                        _SplusNVRAM.TEMPDAY = (ushort) ( Functions.Min( _SplusNVRAM.TEMPDAY , 30 ) ) ; 
                        __context__.SourceCodeLine = 173;
                        _SplusNVRAM.JDAY = (ushort) ( (_SplusNVRAM.TEMPDAY + 304) ) ; 
                        } 
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_2__ == ( 12) ) ) ) 
                        {
                        __context__.SourceCodeLine = 176;
                        _SplusNVRAM.JDAY = (ushort) ( (_SplusNVRAM.TEMPDAY + 334) ) ; 
                        }
                    
                    } 
                    
                }
                
            
            __context__.SourceCodeLine = 179;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (_SplusNVRAM.LEAPYEAR == 1) ) && Functions.TestForTrue ( Functions.BoolToInt (_SplusNVRAM.TEMPMONTH != 1) )) ) ) && Functions.TestForTrue ( Functions.BoolToInt (_SplusNVRAM.TEMPMONTH != 2) )) ))  ) ) 
                {
                __context__.SourceCodeLine = 180;
                _SplusNVRAM.JDAY = (ushort) ( (_SplusNVRAM.JDAY + 1) ) ; 
                }
            
            __context__.SourceCodeLine = 182;
            _SplusNVRAM.JDAY = (ushort) ( ((_SplusNVRAM.JDAY + ((_SplusNVRAM.PRVYEAR - 1996) * 365)) + _SplusNVRAM.LEAPS) ) ; 
            
            }
            
        private void GETGDATE (  SplusExecutionContext __context__ ) 
            { 
            
            __context__.SourceCodeLine = 192;
            _SplusNVRAM.TEMPMONTH = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 194;
            _SplusNVRAM.REMCENTS = (ushort) ( (_SplusNVRAM.JDAY / 36524) ) ; 
            __context__.SourceCodeLine = 195;
            _SplusNVRAM.JDAY = (ushort) ( (_SplusNVRAM.JDAY - (36524 * _SplusNVRAM.REMCENTS)) ) ; 
            __context__.SourceCodeLine = 196;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( _SplusNVRAM.JDAY < 1 ))  ) ) 
                { 
                __context__.SourceCodeLine = 197;
                _SplusNVRAM.TEMPYEAR = (ushort) ( (1996 + (100 * _SplusNVRAM.REMCENTS)) ) ; 
                __context__.SourceCodeLine = 198;
                _SplusNVRAM.TEMPDAY = (ushort) ( 365 ) ; 
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 201;
                _SplusNVRAM.REMQUADS = (ushort) ( (_SplusNVRAM.JDAY / 1461) ) ; 
                __context__.SourceCodeLine = 202;
                _SplusNVRAM.JDAY = (ushort) ( (_SplusNVRAM.JDAY - (1461 * _SplusNVRAM.REMQUADS)) ) ; 
                __context__.SourceCodeLine = 203;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( _SplusNVRAM.JDAY < 1 ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 204;
                    _SplusNVRAM.TEMPYEAR = (ushort) ( ((1996 + (100 * _SplusNVRAM.REMCENTS)) + (4 * _SplusNVRAM.REMQUADS)) ) ; 
                    __context__.SourceCodeLine = 205;
                    _SplusNVRAM.TEMPDAY = (ushort) ( (365 + 1) ) ; 
                    } 
                
                else 
                    { 
                    __context__.SourceCodeLine = 208;
                    _SplusNVRAM.REMYEARS = (ushort) ( (_SplusNVRAM.JDAY / 365) ) ; 
                    __context__.SourceCodeLine = 209;
                    _SplusNVRAM.JDAY = (ushort) ( (_SplusNVRAM.JDAY - (365 * _SplusNVRAM.REMYEARS)) ) ; 
                    __context__.SourceCodeLine = 210;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( _SplusNVRAM.JDAY < 1 ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 211;
                        _SplusNVRAM.TEMPYEAR = (ushort) ( (((1996 + (100 * _SplusNVRAM.REMCENTS)) + (4 * _SplusNVRAM.REMQUADS)) + _SplusNVRAM.REMYEARS) ) ; 
                        __context__.SourceCodeLine = 213;
                        _SplusNVRAM.TEMPDAY = (ushort) ( 365 ) ; 
                        } 
                    
                    else 
                        { 
                        __context__.SourceCodeLine = 216;
                        _SplusNVRAM.TEMPYEAR = (ushort) ( ((((1 + 1996) + (100 * _SplusNVRAM.REMCENTS)) + (4 * _SplusNVRAM.REMQUADS)) + _SplusNVRAM.REMYEARS) ) ; 
                        __context__.SourceCodeLine = 218;
                        _SplusNVRAM.TEMPDAY = (ushort) ( _SplusNVRAM.JDAY ) ; 
                        } 
                    
                    } 
                
                } 
            
            __context__.SourceCodeLine = 225;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (Mod( _SplusNVRAM.TEMPYEAR , 4 ) == 0) ) && Functions.TestForTrue ( Functions.BoolToInt (Mod( _SplusNVRAM.TEMPYEAR , 100 ) != 0) )) ) ) || Functions.TestForTrue ( Functions.BoolToInt (Mod( _SplusNVRAM.TEMPYEAR , 400 ) == 0) )) ))  ) ) 
                {
                __context__.SourceCodeLine = 226;
                _SplusNVRAM.LEAPYEAR = (ushort) ( 1 ) ; 
                }
            
            else 
                {
                __context__.SourceCodeLine = 228;
                _SplusNVRAM.LEAPYEAR = (ushort) ( 0 ) ; 
                }
            
            __context__.SourceCodeLine = 230;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( _SplusNVRAM.TEMPDAY < 1 ))  ) ) 
                { 
                __context__.SourceCodeLine = 232;
                _SplusNVRAM.TEMPMONTH = (ushort) ( 12 ) ; 
                __context__.SourceCodeLine = 233;
                _SplusNVRAM.TEMPDAY = (ushort) ( 31 ) ; 
                } 
            
            else 
                {
                __context__.SourceCodeLine = 235;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( _SplusNVRAM.TEMPDAY <= 31 ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 237;
                    _SplusNVRAM.TEMPMONTH = (ushort) ( 1 ) ; 
                    } 
                
                else 
                    {
                    __context__.SourceCodeLine = 239;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( _SplusNVRAM.TEMPDAY <= (_SplusNVRAM.LEAPYEAR + 59) ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 241;
                        _SplusNVRAM.TEMPMONTH = (ushort) ( 2 ) ; 
                        __context__.SourceCodeLine = 242;
                        _SplusNVRAM.TEMPDAY = (ushort) ( (_SplusNVRAM.TEMPDAY - 31) ) ; 
                        } 
                    
                    else 
                        {
                        __context__.SourceCodeLine = 244;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( _SplusNVRAM.TEMPDAY <= (_SplusNVRAM.LEAPYEAR + 90) ))  ) ) 
                            { 
                            __context__.SourceCodeLine = 246;
                            _SplusNVRAM.TEMPMONTH = (ushort) ( 3 ) ; 
                            __context__.SourceCodeLine = 247;
                            _SplusNVRAM.TEMPDAY = (ushort) ( ((_SplusNVRAM.TEMPDAY - _SplusNVRAM.LEAPYEAR) - 59) ) ; 
                            } 
                        
                        else 
                            {
                            __context__.SourceCodeLine = 249;
                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( _SplusNVRAM.TEMPDAY <= (_SplusNVRAM.LEAPYEAR + 120) ))  ) ) 
                                { 
                                __context__.SourceCodeLine = 251;
                                _SplusNVRAM.TEMPMONTH = (ushort) ( 4 ) ; 
                                __context__.SourceCodeLine = 252;
                                _SplusNVRAM.TEMPDAY = (ushort) ( ((_SplusNVRAM.TEMPDAY - _SplusNVRAM.LEAPYEAR) - 90) ) ; 
                                } 
                            
                            else 
                                {
                                __context__.SourceCodeLine = 254;
                                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( _SplusNVRAM.TEMPDAY <= (_SplusNVRAM.LEAPYEAR + 151) ))  ) ) 
                                    { 
                                    __context__.SourceCodeLine = 256;
                                    _SplusNVRAM.TEMPMONTH = (ushort) ( 5 ) ; 
                                    __context__.SourceCodeLine = 257;
                                    _SplusNVRAM.TEMPDAY = (ushort) ( ((_SplusNVRAM.TEMPDAY - _SplusNVRAM.LEAPYEAR) - 120) ) ; 
                                    } 
                                
                                else 
                                    {
                                    __context__.SourceCodeLine = 259;
                                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( _SplusNVRAM.TEMPDAY <= (_SplusNVRAM.LEAPYEAR + 181) ))  ) ) 
                                        { 
                                        __context__.SourceCodeLine = 261;
                                        _SplusNVRAM.TEMPMONTH = (ushort) ( 6 ) ; 
                                        __context__.SourceCodeLine = 262;
                                        _SplusNVRAM.TEMPDAY = (ushort) ( ((_SplusNVRAM.TEMPDAY - _SplusNVRAM.LEAPYEAR) - 151) ) ; 
                                        } 
                                    
                                    else 
                                        {
                                        __context__.SourceCodeLine = 264;
                                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( _SplusNVRAM.TEMPDAY <= (_SplusNVRAM.LEAPYEAR + 212) ))  ) ) 
                                            { 
                                            __context__.SourceCodeLine = 266;
                                            _SplusNVRAM.TEMPMONTH = (ushort) ( 7 ) ; 
                                            __context__.SourceCodeLine = 267;
                                            _SplusNVRAM.TEMPDAY = (ushort) ( ((_SplusNVRAM.TEMPDAY - _SplusNVRAM.LEAPYEAR) - 181) ) ; 
                                            } 
                                        
                                        else 
                                            {
                                            __context__.SourceCodeLine = 269;
                                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( _SplusNVRAM.TEMPDAY <= (_SplusNVRAM.LEAPYEAR + 243) ))  ) ) 
                                                { 
                                                __context__.SourceCodeLine = 271;
                                                _SplusNVRAM.TEMPMONTH = (ushort) ( 8 ) ; 
                                                __context__.SourceCodeLine = 272;
                                                _SplusNVRAM.TEMPDAY = (ushort) ( ((_SplusNVRAM.TEMPDAY - _SplusNVRAM.LEAPYEAR) - 212) ) ; 
                                                } 
                                            
                                            else 
                                                {
                                                __context__.SourceCodeLine = 274;
                                                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( _SplusNVRAM.TEMPDAY <= (_SplusNVRAM.LEAPYEAR + 273) ))  ) ) 
                                                    { 
                                                    __context__.SourceCodeLine = 276;
                                                    _SplusNVRAM.TEMPMONTH = (ushort) ( 9 ) ; 
                                                    __context__.SourceCodeLine = 277;
                                                    _SplusNVRAM.TEMPDAY = (ushort) ( ((_SplusNVRAM.TEMPDAY - _SplusNVRAM.LEAPYEAR) - 243) ) ; 
                                                    } 
                                                
                                                else 
                                                    {
                                                    __context__.SourceCodeLine = 279;
                                                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( _SplusNVRAM.TEMPDAY <= (_SplusNVRAM.LEAPYEAR + 304) ))  ) ) 
                                                        { 
                                                        __context__.SourceCodeLine = 281;
                                                        _SplusNVRAM.TEMPMONTH = (ushort) ( 10 ) ; 
                                                        __context__.SourceCodeLine = 282;
                                                        _SplusNVRAM.TEMPDAY = (ushort) ( ((_SplusNVRAM.TEMPDAY - _SplusNVRAM.LEAPYEAR) - 273) ) ; 
                                                        } 
                                                    
                                                    else 
                                                        {
                                                        __context__.SourceCodeLine = 284;
                                                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( _SplusNVRAM.TEMPDAY <= (_SplusNVRAM.LEAPYEAR + 334) ))  ) ) 
                                                            { 
                                                            __context__.SourceCodeLine = 286;
                                                            _SplusNVRAM.TEMPMONTH = (ushort) ( 11 ) ; 
                                                            __context__.SourceCodeLine = 287;
                                                            _SplusNVRAM.TEMPDAY = (ushort) ( ((_SplusNVRAM.TEMPDAY - _SplusNVRAM.LEAPYEAR) - 304) ) ; 
                                                            } 
                                                        
                                                        else 
                                                            { 
                                                            __context__.SourceCodeLine = 291;
                                                            _SplusNVRAM.TEMPMONTH = (ushort) ( 12 ) ; 
                                                            __context__.SourceCodeLine = 292;
                                                            _SplusNVRAM.TEMPDAY = (ushort) ( ((_SplusNVRAM.TEMPDAY - _SplusNVRAM.LEAPYEAR) - 334) ) ; 
                                                            } 
                                                        
                                                        }
                                                    
                                                    }
                                                
                                                }
                                            
                                            }
                                        
                                        }
                                    
                                    }
                                
                                }
                            
                            }
                        
                        }
                    
                    }
                
                }
            
            
            }
            
        private void UPDATETIME (  SplusExecutionContext __context__ ) 
            { 
            
            __context__.SourceCodeLine = 302;
            _SplusNVRAM.EVENTHOUR = (ushort) ( (_SplusNVRAM.EVENTPROPS[ _SplusNVRAM.CURRENTEVENT , 1 ] / 60) ) ; 
            __context__.SourceCodeLine = 303;
            _SplusNVRAM.EVENTMIN = (ushort) ( Mod( _SplusNVRAM.EVENTPROPS[ _SplusNVRAM.CURRENTEVENT , 1 ] , 60 ) ) ; 
            __context__.SourceCodeLine = 306;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( _SplusNVRAM.EVENTHOUR > 23 ))  ) ) 
                {
                __context__.SourceCodeLine = 307;
                _SplusNVRAM.EVENTHOUR = (ushort) ( 12 ) ; 
                }
            
            __context__.SourceCodeLine = 310;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( _SplusNVRAM.EVENTHOUR < 12 ))  ) ) 
                { 
                __context__.SourceCodeLine = 311;
                _SplusNVRAM.AMPM  .UpdateValue ( "AM"  ) ; 
                __context__.SourceCodeLine = 312;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (_SplusNVRAM.EVENTHOUR != 0))  ) ) 
                    { 
                    __context__.SourceCodeLine = 313;
                    _SplusNVRAM.DISPLAYHOUR = (ushort) ( _SplusNVRAM.EVENTHOUR ) ; 
                    } 
                
                else 
                    { 
                    __context__.SourceCodeLine = 316;
                    _SplusNVRAM.DISPLAYHOUR = (ushort) ( 12 ) ; 
                    } 
                
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 320;
                _SplusNVRAM.AMPM  .UpdateValue ( "PM"  ) ; 
                __context__.SourceCodeLine = 321;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (_SplusNVRAM.EVENTHOUR != 12))  ) ) 
                    { 
                    __context__.SourceCodeLine = 322;
                    _SplusNVRAM.DISPLAYHOUR = (ushort) ( (_SplusNVRAM.EVENTHOUR - 12) ) ; 
                    } 
                
                else 
                    { 
                    __context__.SourceCodeLine = 325;
                    _SplusNVRAM.DISPLAYHOUR = (ushort) ( 12 ) ; 
                    } 
                
                } 
            
            __context__.SourceCodeLine = 329;
            MakeString ( EVENT_TIME__DOLLAR__ , "{0:d2}:{1:d2} {2}", (short)_SplusNVRAM.DISPLAYHOUR, (short)_SplusNVRAM.EVENTMIN, _SplusNVRAM.AMPM ) ; 
            
            }
            
        private void BUILDTIME (  SplusExecutionContext __context__ ) 
            { 
            
            __context__.SourceCodeLine = 337;
            _SplusNVRAM.EVENTPROPS [ _SplusNVRAM.CURRENTEVENT , 1] = (ushort) ( ((_SplusNVRAM.EVENTHOUR * 60) + _SplusNVRAM.EVENTMIN) ) ; 
            
            }
            
        private void UPDATEDATE (  SplusExecutionContext __context__ ) 
            { 
            
            __context__.SourceCodeLine = 346;
            _SplusNVRAM.JDAY = (ushort) ( _SplusNVRAM.EVENTPROPS[ _SplusNVRAM.CURRENTEVENT , 0 ] ) ; 
            __context__.SourceCodeLine = 347;
            GETGDATE (  __context__  ) ; 
            __context__.SourceCodeLine = 348;
            _SplusNVRAM.EVENTMONTH = (ushort) ( _SplusNVRAM.TEMPMONTH ) ; 
            __context__.SourceCodeLine = 349;
            _SplusNVRAM.EVENTDAY = (ushort) ( _SplusNVRAM.TEMPDAY ) ; 
            __context__.SourceCodeLine = 350;
            _SplusNVRAM.EVENTYEAR = (ushort) ( _SplusNVRAM.TEMPYEAR ) ; 
            __context__.SourceCodeLine = 353;
            
                {
                int __SPLS_TMPVAR__SWTCH_3__ = ((int)_SplusNVRAM.EVENTMONTH);
                
                    { 
                    if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_3__ == ( 1) ) ) ) 
                        { 
                        __context__.SourceCodeLine = 355;
                        _SplusNVRAM.DAYSPERMONTH = (ushort) ( 31 ) ; 
                        __context__.SourceCodeLine = 356;
                        _SplusNVRAM.MONTH__DOLLAR__  .UpdateValue ( "January"  ) ; 
                        } 
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_3__ == ( 2) ) ) ) 
                        { 
                        __context__.SourceCodeLine = 359;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Mod( _SplusNVRAM.EVENTYEAR , 4 ) == 0))  ) ) 
                            {
                            __context__.SourceCodeLine = 360;
                            _SplusNVRAM.DAYSPERMONTH = (ushort) ( 29 ) ; 
                            }
                        
                        else 
                            {
                            __context__.SourceCodeLine = 362;
                            _SplusNVRAM.DAYSPERMONTH = (ushort) ( 28 ) ; 
                            }
                        
                        __context__.SourceCodeLine = 363;
                        _SplusNVRAM.MONTH__DOLLAR__  .UpdateValue ( "February"  ) ; 
                        } 
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_3__ == ( 3) ) ) ) 
                        { 
                        __context__.SourceCodeLine = 365;
                        _SplusNVRAM.DAYSPERMONTH = (ushort) ( 31 ) ; 
                        __context__.SourceCodeLine = 366;
                        _SplusNVRAM.MONTH__DOLLAR__  .UpdateValue ( "March"  ) ; 
                        } 
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_3__ == ( 4) ) ) ) 
                        { 
                        __context__.SourceCodeLine = 368;
                        _SplusNVRAM.DAYSPERMONTH = (ushort) ( 30 ) ; 
                        __context__.SourceCodeLine = 369;
                        _SplusNVRAM.MONTH__DOLLAR__  .UpdateValue ( "April"  ) ; 
                        } 
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_3__ == ( 5) ) ) ) 
                        { 
                        __context__.SourceCodeLine = 371;
                        _SplusNVRAM.DAYSPERMONTH = (ushort) ( 31 ) ; 
                        __context__.SourceCodeLine = 372;
                        _SplusNVRAM.MONTH__DOLLAR__  .UpdateValue ( "May"  ) ; 
                        } 
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_3__ == ( 6) ) ) ) 
                        { 
                        __context__.SourceCodeLine = 374;
                        _SplusNVRAM.DAYSPERMONTH = (ushort) ( 30 ) ; 
                        __context__.SourceCodeLine = 375;
                        _SplusNVRAM.MONTH__DOLLAR__  .UpdateValue ( "June"  ) ; 
                        } 
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_3__ == ( 7) ) ) ) 
                        { 
                        __context__.SourceCodeLine = 377;
                        _SplusNVRAM.DAYSPERMONTH = (ushort) ( 31 ) ; 
                        __context__.SourceCodeLine = 378;
                        _SplusNVRAM.MONTH__DOLLAR__  .UpdateValue ( "July"  ) ; 
                        } 
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_3__ == ( 8) ) ) ) 
                        { 
                        __context__.SourceCodeLine = 380;
                        _SplusNVRAM.DAYSPERMONTH = (ushort) ( 31 ) ; 
                        __context__.SourceCodeLine = 381;
                        _SplusNVRAM.MONTH__DOLLAR__  .UpdateValue ( "August"  ) ; 
                        } 
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_3__ == ( 9) ) ) ) 
                        { 
                        __context__.SourceCodeLine = 383;
                        _SplusNVRAM.DAYSPERMONTH = (ushort) ( 30 ) ; 
                        __context__.SourceCodeLine = 384;
                        _SplusNVRAM.MONTH__DOLLAR__  .UpdateValue ( "September"  ) ; 
                        } 
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_3__ == ( 10) ) ) ) 
                        { 
                        __context__.SourceCodeLine = 386;
                        _SplusNVRAM.DAYSPERMONTH = (ushort) ( 31 ) ; 
                        __context__.SourceCodeLine = 387;
                        _SplusNVRAM.MONTH__DOLLAR__  .UpdateValue ( "October"  ) ; 
                        } 
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_3__ == ( 11) ) ) ) 
                        { 
                        __context__.SourceCodeLine = 389;
                        _SplusNVRAM.DAYSPERMONTH = (ushort) ( 30 ) ; 
                        __context__.SourceCodeLine = 390;
                        _SplusNVRAM.MONTH__DOLLAR__  .UpdateValue ( "November"  ) ; 
                        } 
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_3__ == ( 12) ) ) ) 
                        { 
                        __context__.SourceCodeLine = 392;
                        _SplusNVRAM.DAYSPERMONTH = (ushort) ( 31 ) ; 
                        __context__.SourceCodeLine = 393;
                        _SplusNVRAM.MONTH__DOLLAR__  .UpdateValue ( "December"  ) ; 
                        } 
                    
                    } 
                    
                }
                
            
            __context__.SourceCodeLine = 395;
            GETDAYOFWEEK (  __context__  ) ; 
            __context__.SourceCodeLine = 396;
            MakeString ( EVENT_DATE__DOLLAR__ , "{0} {1:d}, {2:d4} ({3})", _SplusNVRAM.MONTH__DOLLAR__ , (short)_SplusNVRAM.EVENTDAY, (short)_SplusNVRAM.EVENTYEAR, _SplusNVRAM.DAYOFWEEK__DOLLAR__ ) ; 
            
            }
            
        private void BUILDDATE (  SplusExecutionContext __context__ ) 
            { 
            
            __context__.SourceCodeLine = 407;
            _SplusNVRAM.TEMPDAY = (ushort) ( _SplusNVRAM.EVENTDAY ) ; 
            __context__.SourceCodeLine = 408;
            _SplusNVRAM.TEMPMONTH = (ushort) ( _SplusNVRAM.EVENTMONTH ) ; 
            __context__.SourceCodeLine = 409;
            _SplusNVRAM.TEMPYEAR = (ushort) ( _SplusNVRAM.EVENTYEAR ) ; 
            __context__.SourceCodeLine = 410;
            GETJDAY (  __context__  ) ; 
            __context__.SourceCodeLine = 411;
            _SplusNVRAM.EVENTPROPS [ _SplusNVRAM.CURRENTEVENT , 0] = (ushort) ( _SplusNVRAM.JDAY ) ; 
            
            }
            
        private void UPDATETYPE (  SplusExecutionContext __context__ ) 
            { 
            
            __context__.SourceCodeLine = 419;
            
                {
                int __SPLS_TMPVAR__SWTCH_4__ = ((int)_SplusNVRAM.EVENTPROPS[ _SplusNVRAM.CURRENTEVENT , 2 ]);
                
                    { 
                    if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_4__ == ( 0) ) ) ) 
                        {
                        __context__.SourceCodeLine = 421;
                        EVENT_TYPE__DOLLAR__  .UpdateValue ( "Do once"  ) ; 
                        }
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_4__ == ( 1) ) ) ) 
                        {
                        __context__.SourceCodeLine = 423;
                        EVENT_TYPE__DOLLAR__  .UpdateValue ( "Repeat every " + Functions.ItoA (  (int) ( _SplusNVRAM.EVENTPROPS[ _SplusNVRAM.CURRENTEVENT , 3 ] ) ) + " day(s)"  ) ; 
                        }
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_4__ == ( 2) ) ) ) 
                        {
                        __context__.SourceCodeLine = 425;
                        EVENT_TYPE__DOLLAR__  .UpdateValue ( "Repeat every " + Functions.ItoA (  (int) ( _SplusNVRAM.EVENTPROPS[ _SplusNVRAM.CURRENTEVENT , 3 ] ) ) + " week(s)"  ) ; 
                        }
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_4__ == ( 3) ) ) ) 
                        {
                        __context__.SourceCodeLine = 427;
                        EVENT_TYPE__DOLLAR__  .UpdateValue ( "Repeat every " + Functions.ItoA (  (int) ( _SplusNVRAM.EVENTPROPS[ _SplusNVRAM.CURRENTEVENT , 3 ] ) ) + " month(s)"  ) ; 
                        }
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_4__ == ( 4) ) ) ) 
                        {
                        __context__.SourceCodeLine = 429;
                        EVENT_TYPE__DOLLAR__  .UpdateValue ( "Repeat every " + Functions.ItoA (  (int) ( _SplusNVRAM.EVENTPROPS[ _SplusNVRAM.CURRENTEVENT , 3 ] ) ) + " year(s)"  ) ; 
                        }
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_4__ == ( 5) ) ) ) 
                        {
                        __context__.SourceCodeLine = 431;
                        EVENT_TYPE__DOLLAR__  .UpdateValue ( "Event completed"  ) ; 
                        }
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_4__ == ( 6) ) ) ) 
                        {
                        __context__.SourceCodeLine = 433;
                        EVENT_TYPE__DOLLAR__  .UpdateValue ( "Event was missed"  ) ; 
                        }
                    
                    } 
                    
                }
                
            
            
            }
            
        private void TRIGGEREVENT (  SplusExecutionContext __context__ ) 
            { 
            
            __context__.SourceCodeLine = 443;
            EVENT_TRIG  .Value = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 444;
            Functions.ProcessLogic ( ) ; 
            __context__.SourceCodeLine = 445;
            EVENT_TRIG  .Value = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 446;
            Functions.ProcessLogic ( ) ; 
            __context__.SourceCodeLine = 448;
            MakeString ( MESSAGE__DOLLAR__ , "Event {0:d} triggered at {1} on {2:d2}/{3:d2}/{4:d4}", (short)EVENT_DUE  .Value, Functions.Left ( Functions.Time ( ) ,  (int) ( 5 ) ) , (short)Functions.GetMonthNum(), (short)Functions.GetDateNum(), (short)Functions.GetYearNum()) ; 
            
            }
            
        private void RESCHEDULEEVENT (  SplusExecutionContext __context__ ) 
            { 
            
            __context__.SourceCodeLine = 458;
            
                {
                int __SPLS_TMPVAR__SWTCH_5__ = ((int)_SplusNVRAM.EVENTPROPS[ EVENT_DUE  .Value , 2 ]);
                
                    { 
                    if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_5__ == ( 0) ) ) ) 
                        { 
                        __context__.SourceCodeLine = 461;
                        _SplusNVRAM.EVENTPROPS [ EVENT_DUE  .Value , 2] = (ushort) ( 5 ) ; 
                        } 
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_5__ == ( 1) ) ) ) 
                        { 
                        __context__.SourceCodeLine = 464;
                        _SplusNVRAM.EVENTPROPS [ EVENT_DUE  .Value , 0] = (ushort) ( (_SplusNVRAM.EVENTPROPS[ EVENT_DUE  .Value , 0 ] + _SplusNVRAM.EVENTPROPS[ EVENT_DUE  .Value , 3 ]) ) ; 
                        } 
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_5__ == ( 2) ) ) ) 
                        { 
                        __context__.SourceCodeLine = 467;
                        _SplusNVRAM.EVENTPROPS [ EVENT_DUE  .Value , 0] = (ushort) ( (_SplusNVRAM.EVENTPROPS[ EVENT_DUE  .Value , 0 ] + (_SplusNVRAM.EVENTPROPS[ EVENT_DUE  .Value , 3 ] * 7)) ) ; 
                        } 
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_5__ == ( 3) ) ) ) 
                        { 
                        __context__.SourceCodeLine = 470;
                        _SplusNVRAM.JDAY = (ushort) ( _SplusNVRAM.EVENTPROPS[ EVENT_DUE  .Value , 0 ] ) ; 
                        __context__.SourceCodeLine = 471;
                        GETGDATE (  __context__  ) ; 
                        __context__.SourceCodeLine = 473;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (_SplusNVRAM.TEMPMONTH + _SplusNVRAM.EVENTPROPS[ EVENT_DUE  .Value , 3 ]) > 12 ))  ) ) 
                            { 
                            __context__.SourceCodeLine = 474;
                            _SplusNVRAM.TEMPYEAR = (ushort) ( (_SplusNVRAM.TEMPYEAR + ((_SplusNVRAM.TEMPMONTH + _SplusNVRAM.EVENTPROPS[ EVENT_DUE  .Value , 3 ]) / 12)) ) ; 
                            __context__.SourceCodeLine = 475;
                            _SplusNVRAM.TEMPMONTH = (ushort) ( Mod( ((_SplusNVRAM.TEMPMONTH + _SplusNVRAM.EVENTPROPS[ EVENT_DUE  .Value , 3 ]) + ((_SplusNVRAM.TEMPMONTH + _SplusNVRAM.EVENTPROPS[ EVENT_DUE  .Value , 3 ]) / 12)) , 13 ) ) ; 
                            } 
                        
                        else 
                            {
                            __context__.SourceCodeLine = 479;
                            _SplusNVRAM.TEMPMONTH = (ushort) ( (_SplusNVRAM.TEMPMONTH + _SplusNVRAM.EVENTPROPS[ EVENT_DUE  .Value , 3 ]) ) ; 
                            }
                        
                        __context__.SourceCodeLine = 481;
                        GETJDAY (  __context__  ) ; 
                        __context__.SourceCodeLine = 482;
                        _SplusNVRAM.EVENTPROPS [ EVENT_DUE  .Value , 0] = (ushort) ( _SplusNVRAM.JDAY ) ; 
                        } 
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_5__ == ( 4) ) ) ) 
                        { 
                        __context__.SourceCodeLine = 486;
                        _SplusNVRAM.JDAY = (ushort) ( _SplusNVRAM.EVENTPROPS[ EVENT_DUE  .Value , 0 ] ) ; 
                        __context__.SourceCodeLine = 487;
                        GETGDATE (  __context__  ) ; 
                        __context__.SourceCodeLine = 488;
                        _SplusNVRAM.TEMPYEAR = (ushort) ( (_SplusNVRAM.TEMPYEAR + _SplusNVRAM.EVENTPROPS[ EVENT_DUE  .Value , 3 ]) ) ; 
                        __context__.SourceCodeLine = 489;
                        GETJDAY (  __context__  ) ; 
                        __context__.SourceCodeLine = 490;
                        _SplusNVRAM.EVENTPROPS [ EVENT_DUE  .Value , 0] = (ushort) ( _SplusNVRAM.JDAY ) ; 
                        } 
                    
                    } 
                    
                }
                
            
            
            }
            
        private void RESETTYPE (  SplusExecutionContext __context__ ) 
            { 
            
            __context__.SourceCodeLine = 499;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( _SplusNVRAM.EVENTPROPS[ _SplusNVRAM.CURRENTEVENT , 2 ] >= 5 ))  ) ) 
                { 
                __context__.SourceCodeLine = 500;
                _SplusNVRAM.EVENTPROPS [ _SplusNVRAM.CURRENTEVENT , 2] = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 501;
                UPDATETYPE (  __context__  ) ; 
                } 
            
            
            }
            
        object HOUR_UP_OnPush_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                
                __context__.SourceCodeLine = 511;
                _SplusNVRAM.EVENTHOUR = (ushort) ( Mod( (_SplusNVRAM.EVENTHOUR + 1) , 24 ) ) ; 
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler( __SignalEventArg__ ); }
            return this;
            
        }
        
    object HOUR_DOWN_OnPush_1 ( Object __EventInfo__ )
    
        { 
        Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
        try
        {
            SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
            
            __context__.SourceCodeLine = 516;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( _SplusNVRAM.EVENTHOUR > 0 ))  ) ) 
                { 
                __context__.SourceCodeLine = 517;
                _SplusNVRAM.EVENTHOUR = (ushort) ( (_SplusNVRAM.EVENTHOUR - 1) ) ; 
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 520;
                _SplusNVRAM.EVENTHOUR = (ushort) ( 23 ) ; 
                } 
            
            
            
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler( __SignalEventArg__ ); }
        return this;
        
    }
    
object MINUTE_UP_OnPush_2 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 526;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( _SplusNVRAM.EVENTMIN < 59 ))  ) ) 
            { 
            __context__.SourceCodeLine = 527;
            _SplusNVRAM.EVENTMIN = (ushort) ( (_SplusNVRAM.EVENTMIN + 1) ) ; 
            } 
        
        else 
            { 
            __context__.SourceCodeLine = 530;
            _SplusNVRAM.EVENTMIN = (ushort) ( 0 ) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object MINUTE_DOWN_OnPush_3 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 537;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( _SplusNVRAM.EVENTMIN > 0 ))  ) ) 
            { 
            __context__.SourceCodeLine = 538;
            _SplusNVRAM.EVENTMIN = (ushort) ( (_SplusNVRAM.EVENTMIN - 1) ) ; 
            } 
        
        else 
            { 
            __context__.SourceCodeLine = 541;
            _SplusNVRAM.EVENTMIN = (ushort) ( 59 ) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object NOW_OnPush_4 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 547;
        _SplusNVRAM.EVENTHOUR = (ushort) ( Functions.GetHourNum() ) ; 
        __context__.SourceCodeLine = 548;
        _SplusNVRAM.EVENTMIN = (ushort) ( Functions.GetMinutesNum() ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object HOUR_UP_OnPush_5 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 553;
        BUILDTIME (  __context__  ) ; 
        __context__.SourceCodeLine = 554;
        UPDATETIME (  __context__  ) ; 
        __context__.SourceCodeLine = 555;
        RESETTYPE (  __context__  ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object REPEAT_TYPE_OnChange_6 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 560;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( REPEAT_TYPE  .UshortValue < 5 ))  ) ) 
            {
            __context__.SourceCodeLine = 561;
            _SplusNVRAM.EVENTPROPS [ _SplusNVRAM.CURRENTEVENT , 2] = (ushort) ( REPEAT_TYPE  .UshortValue ) ; 
            }
        
        else 
            {
            __context__.SourceCodeLine = 563;
            _SplusNVRAM.EVENTPROPS [ _SplusNVRAM.CURRENTEVENT , 2] = (ushort) ( 0 ) ; 
            }
        
        __context__.SourceCodeLine = 565;
        
            {
            int __SPLS_TMPVAR__SWTCH_6__ = ((int)_SplusNVRAM.EVENTPROPS[ _SplusNVRAM.CURRENTEVENT , 2 ]);
            
                { 
                if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_6__ == ( 1) ) ) ) 
                    { 
                    __context__.SourceCodeLine = 567;
                    _SplusNVRAM.MAXREPEATVALUE = (ushort) ( 31 ) ; 
                    } 
                
                else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_6__ == ( 2) ) ) ) 
                    { 
                    __context__.SourceCodeLine = 569;
                    _SplusNVRAM.MAXREPEATVALUE = (ushort) ( 52 ) ; 
                    } 
                
                else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_6__ == ( 3) ) ) ) 
                    { 
                    __context__.SourceCodeLine = 571;
                    _SplusNVRAM.MAXREPEATVALUE = (ushort) ( 36 ) ; 
                    } 
                
                else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_6__ == ( 4) ) ) ) 
                    { 
                    __context__.SourceCodeLine = 573;
                    _SplusNVRAM.MAXREPEATVALUE = (ushort) ( 10 ) ; 
                    } 
                
                } 
                
            }
            
        
        __context__.SourceCodeLine = 576;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( _SplusNVRAM.EVENTPROPS[ _SplusNVRAM.CURRENTEVENT , 3 ] > _SplusNVRAM.MAXREPEATVALUE ))  ) ) 
            {
            __context__.SourceCodeLine = 577;
            _SplusNVRAM.EVENTPROPS [ _SplusNVRAM.CURRENTEVENT , 3] = (ushort) ( _SplusNVRAM.MAXREPEATVALUE ) ; 
            }
        
        __context__.SourceCodeLine = 579;
        UPDATETYPE (  __context__  ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object REPEAT_VALUE_UP_OnPush_7 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 584;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( _SplusNVRAM.EVENTPROPS[ _SplusNVRAM.CURRENTEVENT , 3 ] >= _SplusNVRAM.MAXREPEATVALUE ))  ) ) 
            { 
            __context__.SourceCodeLine = 585;
            _SplusNVRAM.EVENTPROPS [ _SplusNVRAM.CURRENTEVENT , 3] = (ushort) ( 1 ) ; 
            } 
        
        else 
            { 
            __context__.SourceCodeLine = 587;
            _SplusNVRAM.EVENTPROPS [ _SplusNVRAM.CURRENTEVENT , 3] = (ushort) ( (_SplusNVRAM.EVENTPROPS[ _SplusNVRAM.CURRENTEVENT , 3 ] + 1) ) ; 
            } 
        
        __context__.SourceCodeLine = 589;
        UPDATETYPE (  __context__  ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object REPEAT_VALUE_DOWN_OnPush_8 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 594;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( _SplusNVRAM.EVENTPROPS[ _SplusNVRAM.CURRENTEVENT , 3 ] <= 1 ))  ) ) 
            { 
            __context__.SourceCodeLine = 595;
            _SplusNVRAM.EVENTPROPS [ _SplusNVRAM.CURRENTEVENT , 3] = (ushort) ( _SplusNVRAM.MAXREPEATVALUE ) ; 
            } 
        
        else 
            { 
            __context__.SourceCodeLine = 597;
            _SplusNVRAM.EVENTPROPS [ _SplusNVRAM.CURRENTEVENT , 3] = (ushort) ( (_SplusNVRAM.EVENTPROPS[ _SplusNVRAM.CURRENTEVENT , 3 ] - 1) ) ; 
            } 
        
        __context__.SourceCodeLine = 599;
        UPDATETYPE (  __context__  ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object MONTH_UP_OnPush_9 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 604;
        _SplusNVRAM.EVENTMONTH = (ushort) ( (Mod( _SplusNVRAM.EVENTMONTH , 12 ) + 1) ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object MONTH_DOWN_OnPush_10 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 609;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( _SplusNVRAM.EVENTMONTH > 1 ))  ) ) 
            {
            __context__.SourceCodeLine = 610;
            _SplusNVRAM.EVENTMONTH = (ushort) ( (_SplusNVRAM.EVENTMONTH - 1) ) ; 
            }
        
        else 
            {
            __context__.SourceCodeLine = 612;
            _SplusNVRAM.EVENTMONTH = (ushort) ( 12 ) ; 
            }
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object DAY_UP_OnPush_11 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 617;
        _SplusNVRAM.EVENTDAY = (ushort) ( (Mod( _SplusNVRAM.EVENTDAY , _SplusNVRAM.DAYSPERMONTH ) + 1) ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object DAY_DOWN_OnPush_12 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 622;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( _SplusNVRAM.EVENTDAY > 1 ))  ) ) 
            {
            __context__.SourceCodeLine = 623;
            _SplusNVRAM.EVENTDAY = (ushort) ( (_SplusNVRAM.EVENTDAY - 1) ) ; 
            }
        
        else 
            {
            __context__.SourceCodeLine = 625;
            _SplusNVRAM.EVENTDAY = (ushort) ( _SplusNVRAM.DAYSPERMONTH ) ; 
            }
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object YEAR_UP_OnPush_13 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 630;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( _SplusNVRAM.EVENTYEAR >= 2057 ))  ) ) 
            {
            __context__.SourceCodeLine = 631;
            _SplusNVRAM.EVENTYEAR = (ushort) ( Functions.GetYearNum() ) ; 
            }
        
        else 
            {
            __context__.SourceCodeLine = 633;
            _SplusNVRAM.EVENTYEAR = (ushort) ( (_SplusNVRAM.EVENTYEAR + 1) ) ; 
            }
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object YEAR_DOWN_OnPush_14 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 638;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( _SplusNVRAM.EVENTYEAR <= Functions.GetYearNum() ))  ) ) 
            {
            __context__.SourceCodeLine = 639;
            _SplusNVRAM.EVENTYEAR = (ushort) ( 2057 ) ; 
            }
        
        else 
            {
            __context__.SourceCodeLine = 641;
            _SplusNVRAM.EVENTYEAR = (ushort) ( (_SplusNVRAM.EVENTYEAR - 1) ) ; 
            }
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object TODAY_OnPush_15 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 646;
        _SplusNVRAM.EVENTDAY = (ushort) ( Functions.GetDateNum() ) ; 
        __context__.SourceCodeLine = 647;
        _SplusNVRAM.EVENTMONTH = (ushort) ( Functions.GetMonthNum() ) ; 
        __context__.SourceCodeLine = 648;
        _SplusNVRAM.EVENTYEAR = (ushort) ( Functions.GetYearNum() ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object YEAR_UP_OnPush_16 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 653;
        BUILDDATE (  __context__  ) ; 
        __context__.SourceCodeLine = 654;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( _SplusNVRAM.EVENTPROPS[ _SplusNVRAM.CURRENTEVENT , 0 ] < _SplusNVRAM.CURRENTDATE ))  ) ) 
            { 
            __context__.SourceCodeLine = 655;
            _SplusNVRAM.EVENTPROPS [ _SplusNVRAM.CURRENTEVENT , 0] = (ushort) ( _SplusNVRAM.CURRENTDATE ) ; 
            __context__.SourceCodeLine = 656;
            MESSAGE__DOLLAR__  .UpdateValue ( "Cannot assign a date earlier than today"  ) ; 
            } 
        
        __context__.SourceCodeLine = 658;
        UPDATEDATE (  __context__  ) ; 
        __context__.SourceCodeLine = 659;
        RESETTYPE (  __context__  ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object EVENT_NUM_OnChange_17 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 665;
        _SplusNVRAM.CURRENTEVENT = (ushort) ( EVENT_NUM  .UshortValue ) ; 
        __context__.SourceCodeLine = 666;
        UPDATETIME (  __context__  ) ; 
        __context__.SourceCodeLine = 667;
        UPDATEDATE (  __context__  ) ; 
        __context__.SourceCodeLine = 668;
        UPDATETYPE (  __context__  ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object NUM_EVENTS_OnChange_18 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 673;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (NUM_EVENTS  .UshortValue == 0))  ) ) 
            {
            __context__.SourceCodeLine = 674;
            _SplusNVRAM.HIGHESTEVENT = (ushort) ( 50 ) ; 
            }
        
        else 
            {
            __context__.SourceCodeLine = 675;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( NUM_EVENTS  .UshortValue > 50 ))  ) ) 
                { 
                __context__.SourceCodeLine = 676;
                MESSAGE__DOLLAR__  .UpdateValue ( "Too many events specified. Maximum of " + Functions.ItoA (  (int) ( 50 ) )  ) ; 
                __context__.SourceCodeLine = 677;
                _SplusNVRAM.HIGHESTEVENT = (ushort) ( 50 ) ; 
                } 
            
            else 
                {
                __context__.SourceCodeLine = 680;
                _SplusNVRAM.HIGHESTEVENT = (ushort) ( NUM_EVENTS  .UshortValue ) ; 
                }
            
            }
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

public override object FunctionMain (  object __obj__ ) 
    { 
    try
    {
        SplusExecutionContext __context__ = SplusFunctionMainStartCode();
        
        __context__.SourceCodeLine = 687;
        _SplusNVRAM.CURRENTEVENT = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 688;
        UPDATEDATE (  __context__  ) ; 
        __context__.SourceCodeLine = 689;
        UPDATETIME (  __context__  ) ; 
        __context__.SourceCodeLine = 690;
        UPDATETYPE (  __context__  ) ; 
        __context__.SourceCodeLine = 694;
        _SplusNVRAM.TEMPDAY = (ushort) ( Functions.GetDateNum() ) ; 
        __context__.SourceCodeLine = 695;
        _SplusNVRAM.TEMPMONTH = (ushort) ( Functions.GetMonthNum() ) ; 
        __context__.SourceCodeLine = 696;
        _SplusNVRAM.TEMPYEAR = (ushort) ( Functions.GetYearNum() ) ; 
        __context__.SourceCodeLine = 697;
        GETJDAY (  __context__  ) ; 
        __context__.SourceCodeLine = 698;
        _SplusNVRAM.CURRENTDATE = (ushort) ( _SplusNVRAM.JDAY ) ; 
        __context__.SourceCodeLine = 700;
        while ( Functions.TestForTrue  ( ( 1)  ) ) 
            { 
            __context__.SourceCodeLine = 703;
            Functions.Delay (  (int) ( (5 * 113) ) ) ; 
            __context__.SourceCodeLine = 704;
            while ( Functions.TestForTrue  ( ( ENABLE  .Value)  ) ) 
                { 
                __context__.SourceCodeLine = 705;
                _SplusNVRAM.NOW__DOLLAR__  .UpdateValue ( Functions.Time ( )  ) ; 
                __context__.SourceCodeLine = 706;
                _SplusNVRAM.CURRENTTIME = (ushort) ( ((Functions.Atoi( Functions.Left( _SplusNVRAM.NOW__DOLLAR__ , (int)( 2 ) ) ) * 60) + Functions.Atoi( Functions.Mid( _SplusNVRAM.NOW__DOLLAR__ , (int)( 4 ) , (int)( 2 ) ) )) ) ; 
                __context__.SourceCodeLine = 707;
                _SplusNVRAM.TEMPDAY = (ushort) ( Functions.GetDateNum() ) ; 
                __context__.SourceCodeLine = 708;
                _SplusNVRAM.TEMPMONTH = (ushort) ( Functions.GetMonthNum() ) ; 
                __context__.SourceCodeLine = 709;
                _SplusNVRAM.TEMPYEAR = (ushort) ( Functions.GetYearNum() ) ; 
                __context__.SourceCodeLine = 710;
                GETJDAY (  __context__  ) ; 
                __context__.SourceCodeLine = 711;
                _SplusNVRAM.CURRENTDATE = (ushort) ( _SplusNVRAM.JDAY ) ; 
                __context__.SourceCodeLine = 712;
                ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
                ushort __FN_FOREND_VAL__1 = (ushort)Functions.Min( _SplusNVRAM.HIGHESTEVENT , 50 ); 
                int __FN_FORSTEP_VAL__1 = (int)1; 
                for ( _SplusNVRAM.I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (_SplusNVRAM.I  >= __FN_FORSTART_VAL__1) && (_SplusNVRAM.I  <= __FN_FOREND_VAL__1) ) : ( (_SplusNVRAM.I  <= __FN_FORSTART_VAL__1) && (_SplusNVRAM.I  >= __FN_FOREND_VAL__1) ) ; _SplusNVRAM.I  += (ushort)__FN_FORSTEP_VAL__1) 
                    { 
                    __context__.SourceCodeLine = 713;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( _SplusNVRAM.EVENTPROPS[ _SplusNVRAM.I , 2 ] < 5 ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 714;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (_SplusNVRAM.EVENTPROPS[ _SplusNVRAM.I , 1 ] == _SplusNVRAM.CURRENTTIME))  ) ) 
                            { 
                            __context__.SourceCodeLine = 715;
                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( _SplusNVRAM.CURRENTDATE > _SplusNVRAM.EVENTPROPS[ _SplusNVRAM.I , 0 ] ))  ) ) 
                                { 
                                __context__.SourceCodeLine = 717;
                                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (_SplusNVRAM.EVENTPROPS[ _SplusNVRAM.I , 2 ] != 0))  ) ) 
                                    { 
                                    __context__.SourceCodeLine = 718;
                                    EVENT_DUE  .Value = (ushort) ( _SplusNVRAM.I ) ; 
                                    __context__.SourceCodeLine = 719;
                                    do 
                                        { 
                                        __context__.SourceCodeLine = 720;
                                        RESCHEDULEEVENT (  __context__  ) ; 
                                        } 
                                    while (false == ( Functions.TestForTrue  ( Functions.BoolToInt ( _SplusNVRAM.EVENTPROPS[ _SplusNVRAM.I , 0 ] >= _SplusNVRAM.CURRENTDATE )) )); 
                                    __context__.SourceCodeLine = 722;
                                    UPDATEDATE (  __context__  ) ; 
                                    } 
                                
                                else 
                                    { 
                                    __context__.SourceCodeLine = 724;
                                    _SplusNVRAM.EVENTPROPS [ _SplusNVRAM.I , 2] = (ushort) ( 6 ) ; 
                                    __context__.SourceCodeLine = 725;
                                    UPDATETYPE (  __context__  ) ; 
                                    } 
                                
                                } 
                            
                            __context__.SourceCodeLine = 728;
                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (_SplusNVRAM.CURRENTDATE == _SplusNVRAM.EVENTPROPS[ _SplusNVRAM.I , 0 ]))  ) ) 
                                { 
                                __context__.SourceCodeLine = 729;
                                EVENT_DUE  .Value = (ushort) ( _SplusNVRAM.I ) ; 
                                __context__.SourceCodeLine = 730;
                                TRIGGEREVENT (  __context__  ) ; 
                                __context__.SourceCodeLine = 731;
                                RESCHEDULEEVENT (  __context__  ) ; 
                                __context__.SourceCodeLine = 732;
                                UPDATEDATE (  __context__  ) ; 
                                __context__.SourceCodeLine = 733;
                                UPDATETYPE (  __context__  ) ; 
                                } 
                            
                            } 
                        
                        } 
                    
                    __context__.SourceCodeLine = 712;
                    } 
                
                __context__.SourceCodeLine = 738;
                Functions.Delay (  (int) ( (5 * 113) ) ) ; 
                __context__.SourceCodeLine = 704;
                } 
            
            __context__.SourceCodeLine = 700;
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler(); }
    return __obj__;
    }
    

public override void LogosSplusInitialize()
{
    SocketInfo __socketinfo__ = new SocketInfo( 1, this );
    InitialParametersClass.ResolveHostName = __socketinfo__.ResolveHostName;
    _SplusNVRAM = new SplusNVRAM( this );
    _SplusNVRAM.EVENTPROPS  = new ushort[ 51,4 ];
    _SplusNVRAM.AMPM  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 2, this );
    _SplusNVRAM.NOW__DOLLAR__  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 8, this );
    _SplusNVRAM.DAYOFWEEK__DOLLAR__  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 9, this );
    _SplusNVRAM.MONTH__DOLLAR__  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 9, this );
    
    ENABLE = new Crestron.Logos.SplusObjects.DigitalInput( ENABLE__DigitalInput__, this );
    m_DigitalInputList.Add( ENABLE__DigitalInput__, ENABLE );
    
    HOUR_UP = new Crestron.Logos.SplusObjects.DigitalInput( HOUR_UP__DigitalInput__, this );
    m_DigitalInputList.Add( HOUR_UP__DigitalInput__, HOUR_UP );
    
    HOUR_DOWN = new Crestron.Logos.SplusObjects.DigitalInput( HOUR_DOWN__DigitalInput__, this );
    m_DigitalInputList.Add( HOUR_DOWN__DigitalInput__, HOUR_DOWN );
    
    MINUTE_UP = new Crestron.Logos.SplusObjects.DigitalInput( MINUTE_UP__DigitalInput__, this );
    m_DigitalInputList.Add( MINUTE_UP__DigitalInput__, MINUTE_UP );
    
    MINUTE_DOWN = new Crestron.Logos.SplusObjects.DigitalInput( MINUTE_DOWN__DigitalInput__, this );
    m_DigitalInputList.Add( MINUTE_DOWN__DigitalInput__, MINUTE_DOWN );
    
    NOW = new Crestron.Logos.SplusObjects.DigitalInput( NOW__DigitalInput__, this );
    m_DigitalInputList.Add( NOW__DigitalInput__, NOW );
    
    DAY_UP = new Crestron.Logos.SplusObjects.DigitalInput( DAY_UP__DigitalInput__, this );
    m_DigitalInputList.Add( DAY_UP__DigitalInput__, DAY_UP );
    
    DAY_DOWN = new Crestron.Logos.SplusObjects.DigitalInput( DAY_DOWN__DigitalInput__, this );
    m_DigitalInputList.Add( DAY_DOWN__DigitalInput__, DAY_DOWN );
    
    MONTH_UP = new Crestron.Logos.SplusObjects.DigitalInput( MONTH_UP__DigitalInput__, this );
    m_DigitalInputList.Add( MONTH_UP__DigitalInput__, MONTH_UP );
    
    MONTH_DOWN = new Crestron.Logos.SplusObjects.DigitalInput( MONTH_DOWN__DigitalInput__, this );
    m_DigitalInputList.Add( MONTH_DOWN__DigitalInput__, MONTH_DOWN );
    
    YEAR_UP = new Crestron.Logos.SplusObjects.DigitalInput( YEAR_UP__DigitalInput__, this );
    m_DigitalInputList.Add( YEAR_UP__DigitalInput__, YEAR_UP );
    
    YEAR_DOWN = new Crestron.Logos.SplusObjects.DigitalInput( YEAR_DOWN__DigitalInput__, this );
    m_DigitalInputList.Add( YEAR_DOWN__DigitalInput__, YEAR_DOWN );
    
    TODAY = new Crestron.Logos.SplusObjects.DigitalInput( TODAY__DigitalInput__, this );
    m_DigitalInputList.Add( TODAY__DigitalInput__, TODAY );
    
    REPEAT_VALUE_UP = new Crestron.Logos.SplusObjects.DigitalInput( REPEAT_VALUE_UP__DigitalInput__, this );
    m_DigitalInputList.Add( REPEAT_VALUE_UP__DigitalInput__, REPEAT_VALUE_UP );
    
    REPEAT_VALUE_DOWN = new Crestron.Logos.SplusObjects.DigitalInput( REPEAT_VALUE_DOWN__DigitalInput__, this );
    m_DigitalInputList.Add( REPEAT_VALUE_DOWN__DigitalInput__, REPEAT_VALUE_DOWN );
    
    EVENT_TRIG = new Crestron.Logos.SplusObjects.DigitalOutput( EVENT_TRIG__DigitalOutput__, this );
    m_DigitalOutputList.Add( EVENT_TRIG__DigitalOutput__, EVENT_TRIG );
    
    EVENT_NUM = new Crestron.Logos.SplusObjects.AnalogInput( EVENT_NUM__AnalogSerialInput__, this );
    m_AnalogInputList.Add( EVENT_NUM__AnalogSerialInput__, EVENT_NUM );
    
    NUM_EVENTS = new Crestron.Logos.SplusObjects.AnalogInput( NUM_EVENTS__AnalogSerialInput__, this );
    m_AnalogInputList.Add( NUM_EVENTS__AnalogSerialInput__, NUM_EVENTS );
    
    REPEAT_TYPE = new Crestron.Logos.SplusObjects.AnalogInput( REPEAT_TYPE__AnalogSerialInput__, this );
    m_AnalogInputList.Add( REPEAT_TYPE__AnalogSerialInput__, REPEAT_TYPE );
    
    EVENT_DUE = new Crestron.Logos.SplusObjects.AnalogOutput( EVENT_DUE__AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( EVENT_DUE__AnalogSerialOutput__, EVENT_DUE );
    
    EVENT_TYPE__DOLLAR__ = new Crestron.Logos.SplusObjects.StringOutput( EVENT_TYPE__DOLLAR____AnalogSerialOutput__, this );
    m_StringOutputList.Add( EVENT_TYPE__DOLLAR____AnalogSerialOutput__, EVENT_TYPE__DOLLAR__ );
    
    EVENT_DATE__DOLLAR__ = new Crestron.Logos.SplusObjects.StringOutput( EVENT_DATE__DOLLAR____AnalogSerialOutput__, this );
    m_StringOutputList.Add( EVENT_DATE__DOLLAR____AnalogSerialOutput__, EVENT_DATE__DOLLAR__ );
    
    EVENT_TIME__DOLLAR__ = new Crestron.Logos.SplusObjects.StringOutput( EVENT_TIME__DOLLAR____AnalogSerialOutput__, this );
    m_StringOutputList.Add( EVENT_TIME__DOLLAR____AnalogSerialOutput__, EVENT_TIME__DOLLAR__ );
    
    MESSAGE__DOLLAR__ = new Crestron.Logos.SplusObjects.StringOutput( MESSAGE__DOLLAR____AnalogSerialOutput__, this );
    m_StringOutputList.Add( MESSAGE__DOLLAR____AnalogSerialOutput__, MESSAGE__DOLLAR__ );
    
    
    HOUR_UP.OnDigitalPush.Add( new InputChangeHandlerWrapper( HOUR_UP_OnPush_0, false ) );
    HOUR_DOWN.OnDigitalPush.Add( new InputChangeHandlerWrapper( HOUR_DOWN_OnPush_1, false ) );
    MINUTE_UP.OnDigitalPush.Add( new InputChangeHandlerWrapper( MINUTE_UP_OnPush_2, false ) );
    MINUTE_DOWN.OnDigitalPush.Add( new InputChangeHandlerWrapper( MINUTE_DOWN_OnPush_3, false ) );
    NOW.OnDigitalPush.Add( new InputChangeHandlerWrapper( NOW_OnPush_4, false ) );
    HOUR_UP.OnDigitalPush.Add( new InputChangeHandlerWrapper( HOUR_UP_OnPush_5, false ) );
    HOUR_DOWN.OnDigitalPush.Add( new InputChangeHandlerWrapper( HOUR_UP_OnPush_5, false ) );
    MINUTE_UP.OnDigitalPush.Add( new InputChangeHandlerWrapper( HOUR_UP_OnPush_5, false ) );
    MINUTE_DOWN.OnDigitalPush.Add( new InputChangeHandlerWrapper( HOUR_UP_OnPush_5, false ) );
    NOW.OnDigitalPush.Add( new InputChangeHandlerWrapper( HOUR_UP_OnPush_5, false ) );
    REPEAT_TYPE.OnAnalogChange.Add( new InputChangeHandlerWrapper( REPEAT_TYPE_OnChange_6, false ) );
    REPEAT_VALUE_UP.OnDigitalPush.Add( new InputChangeHandlerWrapper( REPEAT_VALUE_UP_OnPush_7, false ) );
    REPEAT_VALUE_DOWN.OnDigitalPush.Add( new InputChangeHandlerWrapper( REPEAT_VALUE_DOWN_OnPush_8, false ) );
    MONTH_UP.OnDigitalPush.Add( new InputChangeHandlerWrapper( MONTH_UP_OnPush_9, false ) );
    MONTH_DOWN.OnDigitalPush.Add( new InputChangeHandlerWrapper( MONTH_DOWN_OnPush_10, false ) );
    DAY_UP.OnDigitalPush.Add( new InputChangeHandlerWrapper( DAY_UP_OnPush_11, false ) );
    DAY_DOWN.OnDigitalPush.Add( new InputChangeHandlerWrapper( DAY_DOWN_OnPush_12, false ) );
    YEAR_UP.OnDigitalPush.Add( new InputChangeHandlerWrapper( YEAR_UP_OnPush_13, false ) );
    YEAR_DOWN.OnDigitalPush.Add( new InputChangeHandlerWrapper( YEAR_DOWN_OnPush_14, false ) );
    TODAY.OnDigitalPush.Add( new InputChangeHandlerWrapper( TODAY_OnPush_15, false ) );
    YEAR_UP.OnDigitalPush.Add( new InputChangeHandlerWrapper( YEAR_UP_OnPush_16, false ) );
    YEAR_DOWN.OnDigitalPush.Add( new InputChangeHandlerWrapper( YEAR_UP_OnPush_16, false ) );
    MONTH_UP.OnDigitalPush.Add( new InputChangeHandlerWrapper( YEAR_UP_OnPush_16, false ) );
    MONTH_DOWN.OnDigitalPush.Add( new InputChangeHandlerWrapper( YEAR_UP_OnPush_16, false ) );
    DAY_UP.OnDigitalPush.Add( new InputChangeHandlerWrapper( YEAR_UP_OnPush_16, false ) );
    DAY_DOWN.OnDigitalPush.Add( new InputChangeHandlerWrapper( YEAR_UP_OnPush_16, false ) );
    TODAY.OnDigitalPush.Add( new InputChangeHandlerWrapper( YEAR_UP_OnPush_16, false ) );
    EVENT_NUM.OnAnalogChange.Add( new InputChangeHandlerWrapper( EVENT_NUM_OnChange_17, false ) );
    NUM_EVENTS.OnAnalogChange.Add( new InputChangeHandlerWrapper( NUM_EVENTS_OnChange_18, false ) );
    
    _SplusNVRAM.PopulateCustomAttributeList( true );
    
    NVRAM = _SplusNVRAM;
    
}

public override void LogosSimplSharpInitialize()
{
    
    
}

public CrestronModuleClass_EVNTSKED ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}




const uint ENABLE__DigitalInput__ = 0;
const uint HOUR_UP__DigitalInput__ = 1;
const uint HOUR_DOWN__DigitalInput__ = 2;
const uint MINUTE_UP__DigitalInput__ = 3;
const uint MINUTE_DOWN__DigitalInput__ = 4;
const uint NOW__DigitalInput__ = 5;
const uint DAY_UP__DigitalInput__ = 6;
const uint DAY_DOWN__DigitalInput__ = 7;
const uint MONTH_UP__DigitalInput__ = 8;
const uint MONTH_DOWN__DigitalInput__ = 9;
const uint YEAR_UP__DigitalInput__ = 10;
const uint YEAR_DOWN__DigitalInput__ = 11;
const uint TODAY__DigitalInput__ = 12;
const uint REPEAT_VALUE_UP__DigitalInput__ = 13;
const uint REPEAT_VALUE_DOWN__DigitalInput__ = 14;
const uint EVENT_NUM__AnalogSerialInput__ = 0;
const uint NUM_EVENTS__AnalogSerialInput__ = 1;
const uint REPEAT_TYPE__AnalogSerialInput__ = 2;
const uint EVENT_TRIG__DigitalOutput__ = 0;
const uint EVENT_DUE__AnalogSerialOutput__ = 0;
const uint EVENT_TYPE__DOLLAR____AnalogSerialOutput__ = 1;
const uint EVENT_DATE__DOLLAR____AnalogSerialOutput__ = 2;
const uint EVENT_TIME__DOLLAR____AnalogSerialOutput__ = 3;
const uint MESSAGE__DOLLAR____AnalogSerialOutput__ = 4;

[SplusStructAttribute(-1, true, false)]
public class SplusNVRAM : SplusStructureBase
{

    public SplusNVRAM( SplusObject __caller__ ) : base( __caller__ ) {}
    
    [SplusStructAttribute(0, false, true)]
            public ushort [,] EVENTPROPS;
            [SplusStructAttribute(1, false, true)]
            public ushort MAXREPEATVALUE = 0;
            [SplusStructAttribute(2, false, true)]
            public ushort HIGHESTEVENT = 0;
            [SplusStructAttribute(3, false, true)]
            public ushort CURRENTEVENT = 0;
            [SplusStructAttribute(4, false, true)]
            public ushort CURRENTDATE = 0;
            [SplusStructAttribute(5, false, true)]
            public ushort CURRENTTIME = 0;
            [SplusStructAttribute(6, false, true)]
            public ushort DISPLAYHOUR = 0;
            [SplusStructAttribute(7, false, true)]
            public ushort EVENTMIN = 0;
            [SplusStructAttribute(8, false, true)]
            public ushort EVENTHOUR = 0;
            [SplusStructAttribute(9, false, true)]
            public ushort EVENTDAY = 0;
            [SplusStructAttribute(10, false, true)]
            public ushort EVENTMONTH = 0;
            [SplusStructAttribute(11, false, true)]
            public ushort EVENTYEAR = 0;
            [SplusStructAttribute(12, false, true)]
            public ushort DAYSPERMONTH = 0;
            [SplusStructAttribute(13, false, true)]
            public ushort TEMPMONTH = 0;
            [SplusStructAttribute(14, false, true)]
            public ushort TEMPDAY = 0;
            [SplusStructAttribute(15, false, true)]
            public ushort TEMPYEAR = 0;
            [SplusStructAttribute(16, false, true)]
            public ushort I = 0;
            [SplusStructAttribute(17, false, true)]
            public ushort CENT = 0;
            [SplusStructAttribute(18, false, true)]
            public ushort LEAPS = 0;
            [SplusStructAttribute(19, false, true)]
            public ushort LEAPYEAR = 0;
            [SplusStructAttribute(20, false, true)]
            public ushort PRVYEAR = 0;
            [SplusStructAttribute(21, false, true)]
            public ushort JDAY = 0;
            [SplusStructAttribute(22, false, true)]
            public ushort QUADCENTS = 0;
            [SplusStructAttribute(23, false, true)]
            public ushort REMCENTS = 0;
            [SplusStructAttribute(24, false, true)]
            public ushort REMQUADS = 0;
            [SplusStructAttribute(25, false, true)]
            public ushort REMYEARS = 0;
            [SplusStructAttribute(26, false, true)]
            public ushort DAYOFWEEK = 0;
            [SplusStructAttribute(27, false, true)]
            public ushort ZELLERMONTH = 0;
            [SplusStructAttribute(28, false, true)]
            public ushort ZELLERYEAR = 0;
            [SplusStructAttribute(29, false, true)]
            public ushort ZELLERCENTURY = 0;
            [SplusStructAttribute(30, false, true)]
            public ushort N1 = 0;
            [SplusStructAttribute(31, false, true)]
            public ushort N2 = 0;
            [SplusStructAttribute(32, false, true)]
            public CrestronString AMPM;
            [SplusStructAttribute(33, false, true)]
            public CrestronString NOW__DOLLAR__;
            [SplusStructAttribute(34, false, true)]
            public CrestronString DAYOFWEEK__DOLLAR__;
            [SplusStructAttribute(35, false, true)]
            public CrestronString MONTH__DOLLAR__;
            
}

SplusNVRAM _SplusNVRAM = null;

public class __CEvent__ : CEvent
{
    public __CEvent__() {}
    public void Close() { base.Close(); }
    public int Reset() { return base.Reset() ? 1 : 0; }
    public int Set() { return base.Set() ? 1 : 0; }
    public int Wait( int timeOutInMs ) { return base.Wait( timeOutInMs ) ? 1 : 0; }
}
public class __CMutex__ : CMutex
{
    public __CMutex__() {}
    public void Close() { base.Close(); }
    public void ReleaseMutex() { base.ReleaseMutex(); }
    public int WaitForMutex() { return base.WaitForMutex() ? 1 : 0; }
}
 public int IsNull( object obj ){ return (obj == null) ? 1 : 0; }
}


}
