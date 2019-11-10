﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationToInput : MonoBehaviour
{
    Transform m_referenceTransform;

    [SerializeField]Vector3 inputValue;

    public Vector3 InputValues => (inputValue);

    private void Awake()
    {        
        if (m_referenceTransform == null) 
            m_referenceTransform = transform;
    }

    void Update()
    {
        GetInput();
    }

    public void GetInput()
    {  
        Vector3 rotationDelta = transform.forward - Vector3.up;
        inputValue = rotationDelta * Time.deltaTime;
    }
}
/*
 *


                          ,.--..
                       ,:'.   .,'V:.::..  .
                     ,::.,..  . . 'VI:I'.,:-.,.
                    :I:I:.. .   .    MHMHIHI:MHHI:I:,.:.
                   :I:I:.. .   .    MHMHIHI:MHHI:I:,.:.
                   A:I::. ...  .   .MMHHIIHIHI:IHHII:.:,
                  .M:I::... ..   . AMMMMMHI::IHII::II.::.
                  IMA'::.:.. .    .MMMMMHHII:IMHIHIA:::',
                  ,MV.:.:.. .     AMMMMHMHI:I:HIHHIIIA;.
                   P.:.:.. .  .  .MMMMMMMHHIIMHHHIIHIIH.
                   :..:.. . .    AMMMMMMMHHI:AMIVHI:HIII:
                  ,:. :.. .  .    MMMMMMMMMH:IHHI:HHI:HIIH.
                  :..:...  .    .MMMHP:'',,,:HHIH:HHH:HIII
                 ;.:..:.. .     AMH:'. , , ,,':HII:HHH:HII:
                 ::..:.. . .   .H:,.. .     ,'.:VA:I:H::HI:
                ;.:.:... ..    A:.,...     .   ,:HA:IHI::I:
               ,::..:. . .    .M::. .    .      ,:HA:HH:II:.
               ;.::... ..     AML;,,,       .    .:VHI:HI:I:;
              ,:.:.:. . .    .H. 'PA,           .:IHH:HHII::.
             ,:.::... ..     A:I:::';, .   .  ,ILIIIH:HI:I:I;
            ,;:.:.:.. . .   .H:TP'VB,)..   .,;T;,,::I:HI:I:::
           ,::.:.:.. . .    AI:.':IAAT:.  .(,:BB,);V::IH:I:I;
         ,::.:.:.. . .    .H:. , . . ..  .':;AITP;I:IIH:I::;,
        ,::.::.:. . . .   A::.   . ..:.  .  . ..:AI:IHII:I::;.
         ;:.::.:.. .  .   AM:I:.   ..:.   .: . .::HIIIHIIHII::.
        ,:::.:.:..  .    .MM:I:..  .:,    .:.  .::HHIIIHIHII::;
       ,::.:..:.. .   .  AMM:I:.  . .,'-'',,. ..::HIHI:HI:III:
       ;:.::..:.. . .   AMMM::. . ,,,, ,..   ,.::IMHIHIHIIHI::;
      ,:::.:..:. .   .  MMMM:I:.  ,:::;;;::;, .::AMHIHIHHIHHI:'
      ;::.:.:.. . .   .:VMMV:A:. .  ,:;,,.'  .::AMMMIHIHHIHHII
     ;::.:.:.. ..  .  .::VM:IHA:. .,,   , . ..:AMMMMHIHHHIHHII:
     ;:::.:.. .  .. . .::P::IHHAA.. .   .. .:AMMMMMMMIIHHIHHI::
     ;::.:.. .  . .  ..:.:VIHHHIHHA::,,,,,:AMMMMMMMMMHIIHHHHII;
     ;.::.. .    . .  ..:.;VHHIHI:IHIHHIHI:MMMMMMMMMMHIHHIHHII:
     ::.:.. .     ..  ...:.::VHI:IIVIHIHII:MMMMMMMMMMMIHHIHHII:,
     ;:..:. .    ..  . ..:.::::VAII:IIIIII:MMMMMMMMMMMIHHIIHIIHI
     ,;:.. .        . .. ..:...:.VII::III:.VMMMMMMMMMHIHHHIHI::I,
      ;:. . .    , . .. ... . .::.::V::II:..VMMMMMMMMHIHHHIHI::I;
      ;:.. . .     . .. ..:..  .::...:VIITPL:VMMMMMMMVIHHHIH:. :;
      ;:. .  .    . .. ... .   ..:.:.. .:IIIA:.MMMMMVI:HIHIH:. .:
      I:. . .   . .. . .. . . . . ..:.. ..::IIA.VMMMVIHIIHIV:. .,
      I:..    . . .. .... .  .   . .. ... .:.:IA:.VMVIMHIHIH:..:
      I.. .  .  . ..... .       .  . .. . .. .:IIAV:HIMHHIHII:.;
      :. ..   . . .:.. .          .  .. ... ..::.:CVI:MHHIHHI...
      :..  . . .. ..:.               . . ... .:.:::VHA.VIHHMI:..
      :. .. .  . ..:..        . .     . .  ..  .. ...:VIIHIHI: .
      ,:.. .  . .::. .       .::,.      .    .  . .  ...V:IHII..
       ;:.. .. .:I:.        ..:T'::.     .  . .  .  . .  .VIIH:.
       ;:.:.. .:I:..        .::V:::.         . . . .  .    VIII..
       ;:.. ..::::. .        ..::. .      .  . .. . .  .    VIII.
       I:.:.. .:I:.           ..:.,        . . .. :. .  .    'VI:.
       I::......::.  .                    . .. .:.:.:. .       'I:
       II::.. ..::. .       .    .     . .. .. .::::.. .      .:.
       II::.:. ..::. .  . .   .    .     .:. . .:I:::. .       .::HD
       ,I:::.. .: . .. ..  .. . .    .  .::. . .:I:. .         .:V:
        I:. .. .  . . ... ..  .. . .    .. ..  ..::.             .:.
        I:.. .. .  ..:.. .. .. ..  . .      .   .                . :
        ;:.... . ..:::I:.. ..:.. ... .::. . ... . ..              .I.
        ::.:....::.::I:III:I::::I:II:I::.. .:.. . .:. .     .  . .AI:
        ,::.:...:..::::::III::II::::::.. ...::. .  .::. . .. .  .AMMI.
          :::.:.:. ..::::III:II:I:::.:. .. ..::.. ..  ..::,.  ..::HMMI:
         ,:::.:.. ...::I:::I:I:::.:.. :. . ..::.. . . . .,PTIHI:IIHHI:.
          ::I::.:...:::II:I::.:....:.:. . ...::. .  . .  .AI:IHI,,:,  ,.
          ,:::.:... ..I::I::.:....:. .: .. ...::. .  .   III:II:.  ,
           ,I:::..:...:.::I::.:..:. .: .. . ..:... .  .  III.I,
            VI:::.::.::...:II::...:...:. . . .:::. . .   :,,
            ,HI:I::.::.::..:II::.:..:.... . .:.:I:.. .   :
             VI:I:I::.::.:...:I:::I:::.... ..:.:I::...   :
             ,II:I::II:I:::.:.:I:III:I:... ....::::... .  :
              VII::I::I::.::..:.::II::.:.. . .:.::::. .   .
               VI:.:..::II:::..:..::.... .   ..::I::...  . .
               ,I::.. ..::II::..:.::.... . ...::I:::.   .  .
                V::.:.. .:I:II::.:..::.. .. ...:::I::..  . . .
                I:::.:....::III:::.:..:.:.. .:.:II:::. .  . . .
                I::.:::...:::II::.:.:.:... ...:II::.. . . . .  .
                I::..:...:.:::.:.:.:.:..:.. .:II:. .. .    . .   .
               .::.:.:....:.:::.:.:.:.:.: . .:I:... . . . . .  .  .
               :.:.:...:.:.:::.::.:.::.... .:::.. .. .  . .  . .
              .:. ..:.:.:::.:..::.::.:.. . .::.. .. . . .  . . .   :
             .:. .:....::..:.:.:.:.:... .. .NI:.. . .. . . .  . .  :.
            .:. . . ..:.:.::.::.::.::.::.. . :.:.. .. .. . . . . . .)O
           .:.. ... .. ..:.::.::.:::.:..:.. . ..:.. .. .. . .. . . ,()
           ::.:. ...:.. ..:..::..::.:.:.:.:. .:.:... .. .. .:.. ..0OO.
          /:::.:...:.:..:..:..::.::.::.:..:..:.:..:.... ..:.:..:.()',
        (0):::.::...:..:..:...::::I:.:I:.:.:.::.::..:.:...:..::O0O... .
         : ::.:..:.:..:.:..:.:I:.::I:::I::.:I::.I:.::..:.:.::.:/0O/.. .
        .:: ::I:.:..::.::.::.::I:::I::.:I::.::I::.:::.::.I::( ):.:..  .
        '.:: ::I:.:..::.::.::.::I:::I::.:I::.::I::.:::.::.:I::( ):.:.. .
        ::I:::,(,,)OO::.:.::.::III:::III::III::I:::::.:I:'V0O:., .   .
       .:::I::I::-:000::..:::.::::III:I::I::II::I:::IIII( ),) .    . . .
       .:.::I::II:I(,)(  )00):.::.::II:I:II:I:I:::III0OO'.M:M.   . . .
       .. .:.::.:I:I:IIHHI000 ,)OO:II:O:II:III::OO(')00//XXVM . .. . . .
       . .. ..:.::.::II:II:III,(0O0'')!0:III:(0OO)..AMV AXXXXI .. .. . .
       . :.. . .::I:IIIHHII:IHIHH(0),,0OOO( )M00AMMHMM,,XXXXXX.. . .  .
      .:.:.:.. . ..:IHHHII::::.,.MMIIIMMXIMMMMMMMMMMV AXXXV:MI. .. .  .
      ::.:.:.:.:.. . ,,., .. ..:.MMIII:MMIMMMMMMMMMMMM, .X::M.MI.. . . .
     .::.::..::.:.:.:. .  .. .::AMMXXXIAMHMMIHMMMMMMV ...::M.MM ... . ..
     ::.::.::.::.::.:.:.. . .:::MMXXXXI:.:VMMHMPMHVMI ..:I:H-,',,.:. . .
    ::.::..:.:.:..:.:.::.:. . .:MMXXX:IXX:MMMMMLMMAM, ..I:M.  :  ,:.. .
   .::.:..:...:...::.:.::I::...IMM:XXX:XX:LMMMMMI:MV  ..I:V   .   :... .
   :.:.:..:.:.:..:..:::II:II:'..M'.VMXX:XXMMMMMMMI.I ...IVI   .  .::. ..
  :.:.:.:.:.:.::...:.::IHI, - . .'VIMHX:XIIMMV/IMLMI ...HV     .  ::.. .
 .::.:.:.:.:..:.. ..::IHI:-.  . .  ',IX:XXIVMI XMMV I...HI    .   :::...
.::.:.:.:.:.:.. ...:.:IHHHI:., .    .XXX:XX.MMAXMHA I..AMI    .    ::...
::.::.::.:.:.... .:.:IHHIHI'. ..    :XXX:XX:MHHIMMMAI,AHHI     .  :::...
:::.:.:.:.:.:.. .:.::IHHHHI:  ..   ,:XXX:XX:MV''.I,V:,:HHI.    .   :::..
::.::.:.:..:.. ...::IIHHHHI:   .   :.XXX:XXXI:.,.    '-VH:    .    ::.:.
:::.::..:..:.. ..:.:IHHHHHI,   .    ::XX:XXXI:.A. .  'VHH      .   :::..
::.::.::.:... ...:::IIHHHIH   ..    :IAX:XXXIHHH:  .  .:MI    .   .:::..
:::.::.:..... ..:.::IIHHIHH   .     ::XX:IXXIHHV .     'V. . . .  :I:::.
:.::.:.:... ...:.::IIIHHHIH    .    I:XX:XXVHMMI .      I.. .:. . .I::.:
::.:::.:.... ..:.::IIIHIHHH.  .     :'XX:XXXVIVI  . .   ::..:. . .I::::.

  */