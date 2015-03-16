'HDD Guardian is a GUI for smartcl utility, part of smartmontools
'
'home page is http://code.google.com/p/hddguardian/
'
'Copyright (C) 2010-2015 Samuele Parise
'
'This Source Code Form is subject to the terms of the Mozilla Public
'License, v. 2.0. If a copy of the MPL was not distributed with this
'file, You can obtain one at http://mozilla.org/MPL/2.0/.

Module Variables

    '*** boolean values to use during loading settings ***
    Friend isloading_features As Boolean = False
    Friend isloading_performance As Boolean = False
    Friend isloading_devsettings As Boolean = False
    Friend isloading_settings As Boolean = True 'leave this to "True", otherwise numeric up/down controls erases all settings at startup

    '*** device temperature colors ***
    Friend temp_ok As Color = Color.DodgerBlue
    Friend temp_high As Color = Color.DarkOrange
    Friend temp_alarm As Color = Color.Red

    '*** SSD's remaining life colors ***
    Friend life_ok As Color = Color.LimeGreen
    Friend life_low As Color = Color.DarkOrange
    Friend life_out As Color = Color.Red

    '*** health colors ***
    Friend health_fail As Color = Color.Red
    Friend health_passed As Color = Color.Blue
    Friend health_unknown As Color = Color.DarkGray

    '*** warnings, bad sectors, (non medium) errors and defects colors ***
    Friend status_ok As Color = Color.Blue
    Friend status_warning As Color = Color.DarkOrange
    Friend status_fail As Color = Color.Red
    Friend status_unknown As Color = Color.DarkGray
End Module
