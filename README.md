# PriceMarkdown

The application will print pricing labels on a Fingerprint printer using a serial communication.

The app supports external files for a logo, button and label text and print layout. 
If an external file is not found, an internal resource will be used instead.

startlogo.gif		image displayed in start screen, will be centered, max size 480x260@96dpi (VGA devices)

Text can be read from an xml file called "language.xml". Three languages are supported.

Coloring can be defined in an external file called "appColors.xml"

Print layout can be defined in external file called "layout-prn.txt". The layout file has to use five variables (VAR1$ to VAR5$).

The print layout data is send only once in a session.

### buttontexts.xml
### now: language.xml

```
<?xml version="1.0" encoding="utf-8" ?>
<text>
  <buttons>
    <button id="0" text="deutsch" />
    <button id="1" text="english" />
    <button id="2" text="espanol" />
  </buttons>
  <labels>
    <labels0>
      <label id="0" text="Alter Preis" />
      <label id="1" text="Neuer Preis" />
      <label id="2" text="Drucken" />
    </labels0>
    <labels1>
      <label id="0" text="Old Price" />
      <label id="1" text="New Price" />
      <label id="2" text="Print" />
    </labels1>
    <labels2>
      <label id="0" text="Precio antiguo" />
      <label id="1" text="Precio nuevo" />
      <label id="2" text="Imprimir" />
    </labels2>
  </labels>
  <vars>
    <var id="0" text="reduziert" />
    <var id="1" text="reduced" />
    <var id="2" text="muy reducido" />
  </vars>
  <currencies>
    <currency id="0" text="€" />
    <currency id="1" text="$" />
    <currency id="2" text="€" />
  </currencies>
</text>
```
-  buttons represent the text display on the three buttons in the language selection screen
-  labels represent the text displayed in the price markdown screen and printed as 'new price' and 'old price'
-  vars represents the text printed on the label for "reduced"
-  currency represents the currency symbol used on the label

## print layout
The print layout (Intermec Fingerprint Language) can also be supplied as external file "layout-prn.txt". The internal layout is as follows:

### layout-prn.txt
```
SYSVAR(18)=0
INPUT OFF
NEW 
OPEN "tmp:setup.sys" for output as #2
PRINT#2, "MEDIA,MEDIA SIZE,LENGTH,400"
PRINT#2, "MEDIA,MEDIA SIZE,XSTART,0"
PRINT#2, "MEDIA,MEDIA SIZE,WIDTH,420"
PRINT#2, "MEDIA,MEDIA TYPE,LABEL (w GAPS)"
PRINT#2, "FEEDADJ,STARTADJ,-40"
PRINT#2, "FEEDADJ,STOPADJ,0"
PRINT#2, "PRINT DEFS,PRINT SPEED,75"
PRINT#2, "MEDIA,PAPER TYPE,DIRECT THERMAL"
PRINT#2, "MEDIA,PAPER TYPE,DIRECT THERMAL,LABEL CONSTANT,85"
PRINT#2, "MEDIA,PAPER TYPE,DIRECT THERMAL,LABEL FACTOR,40"
PRINT#2, "MEDIA,CONTRAST,+0%"
PRINT#2, "RFID,OFF"
CLOSE #2
Setup "tmp:setup.sys"
Kill "tmp:setup.sys"
OPTIMIZE "BATCH" ON
LTS& OFF
SETUP KEY OFF
SYSVAR(48)=0
FORMAT INPUT CHR$(2),CHR$(3),CHR$(13)
LAYOUT INPUT "tmp:LBLSOFT.LAY"
CLIP ON
CLIP BARCODE ON
XORMODE OFF
qFnt1$="Swiss 721 BT"
qFnt2$="Swiss 721 Bold BT"
qFnt3$="Dom DiagonalCE Bold"
NASC 8
DIR 1
AN 1
PP 3,12:PX 256,375,4
PP 3,140:PL 180,184
AN 5
PP 95,130:FT qFnt1$,14,0,100:II
PRBOX 140,180,0,VAR1$,2,2,"",""
AN 2
PP 270,210:FT qFnt1$,12,0,100:NI:PT VAR2$
PRINT PRSTAT(3),PRSTAT(5),PRSTAT(6)
AN 1
PP PRSTAT(3)-2,213:PRDIAGONAL PRSTAT(5)+1,PRSTAT(6)-16,2,"R"
PP PRSTAT(3),212:FT qFnt1$,10,0,100:NI:PT "€"
AN 2
PP 265,140:FT qFnt2$,18,0,100:NI:PT VAR3$
PRINT PRSTAT(3)
AN 1
PP PRSTAT(3)+PRSTAT(5),140:FT qFnt1$,15,0,100:NI:PT "€"
AN 2
PP 185,30:BARSET "CODE128",1,1,3,90
BARFONT OFF
PB VAR4$
AN 1
DIR 4
PP 375,20:FT qFnt1$,10,0,100:NI:PT VAR4$
LAYOUT END
COPY "TMP:LBLSOFT.LAY","C:PRICE_MARKDOWN.LAY"
LAYOUT RUN "C:PRICE_MARKDOWN.LAY"
INPUT ON
==END==
```

###	CHANGED: NEW Layout with variable currency symbol
```
SYSVAR(18)=0
INPUT OFF
NEW 
OPEN "tmp:setup.sys" for output as #2
PRINT#2, "MEDIA,MEDIA SIZE,LENGTH,400"
PRINT#2, "MEDIA,MEDIA SIZE,XSTART,0"
PRINT#2, "MEDIA,MEDIA SIZE,WIDTH,420"
PRINT#2, "MEDIA,MEDIA TYPE,LABEL (w GAPS)"
PRINT#2, "FEEDADJ,STARTADJ,-40"
PRINT#2, "FEEDADJ,STOPADJ,0"
PRINT#2, "PRINT DEFS,PRINT SPEED,75"
PRINT#2, "MEDIA,PAPER TYPE,DIRECT THERMAL"
PRINT#2, "MEDIA,PAPER TYPE,DIRECT THERMAL,LABEL CONSTANT,85"
PRINT#2, "MEDIA,PAPER TYPE,DIRECT THERMAL,LABEL FACTOR,40"
PRINT#2, "MEDIA,CONTRAST,+0%"
PRINT#2, "RFID,OFF"
CLOSE #2
Setup "tmp:setup.sys"
Kill "tmp:setup.sys"
OPTIMIZE "BATCH" ON
LTS& OFF
SETUP KEY OFF
SYSVAR(48)=0
FORMAT INPUT CHR$(2),CHR$(3),CHR$(13)
LAYOUT INPUT "tmp:LBLSOFT.LAY"
CLIP ON
CLIP BARCODE ON
XORMODE OFF
qFnt1$="Swiss 721 BT"
qFnt2$="Swiss 721 Bold BT"
NASC 8
DIR 1
AN 1
PP 3,12:PX 256,375,4
PP 3,140:PL 180,184
AN 5
PP 95,130:FT qFnt1$,14,0,100:II
PRBOX 140,180,0,VAR1$,2,2,"",""
AN 2
PP 270,210:FT qFnt1$,12,0,100:NI:PT VAR2$
PRINT PRSTAT(3),PRSTAT(5),PRSTAT(6)
AN 1
PP PRSTAT(3)-2,213:PRDIAGONAL PRSTAT(5)+1,PRSTAT(6)-16,2,"R"
PP PRSTAT(3),212:FT qFnt1$,10,0,100:NI:PT VAR5$
AN 2
PP 265,140:FT qFnt2$,18,0,100:NI:PT VAR3$
PRINT PRSTAT(3)
AN 1
PP PRSTAT(3)+PRSTAT(5),140:FT qFnt1$,15,0,100:NI:PT VAR5$
AN 2
PP 185,30:BARSET "CODE128",1,1,3,90
BARFONT OFF
PB VAR4$
AN 1
DIR 4
PP 375,20:FT qFnt1$,10,0,100:NI:PT VAR4$
LAYOUT END
COPY "TMP:LBLSOFT.LAY","C:PRICE_MARKDOWN.LAY"
LAYOUT RUN "C:PRICE_MARKDOWN.LAY"
INPUT ON
```

The print layout data is send only once in a session. The data is send using vars:

## print data using layout
To print a lable you just send the following sequences.
```
LAYOUT END
COPY "TMP:LBLSOFT.LAY","C:PRICE_MARKDOWN.LAY"
LAYOUT RUN "c:PRICE_MARKDOWN.LAY"
INPUT ON
...stark reduziert
9,95
2,85
76589
€

PF
PRINT KEY OFF
```

The line after "INPUT ON" starts with 0x02. The line befor ""PF" holds a 0x03, The lines between these 
two markers are the variable data to be printed into the layout. The VARx$ fields in the layout file are
replaced by the data where line 1 defines VAR1$, line 2 defines VAR2$ and so on.

