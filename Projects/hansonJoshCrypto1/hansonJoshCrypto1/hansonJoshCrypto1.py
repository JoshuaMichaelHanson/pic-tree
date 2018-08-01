import os, sys
from stat import *

myPytonFilesDir = 'C:\TempNew\Python\Crypto\HW1'

fileList = []
currentFile = []
hashList = [['~'] * 1 for x in range(257)]


#right now this function only uses lower case for hex letters

def hexCharToAscii(inputHexChar):
    
    if(inputHexChar == '00'):
        return '?NULL?'
    elif(inputHexChar == '01'):
        return '?SOH?'
    elif(inputHexChar == '02'):
        return '?STX?'
    elif(inputHexChar == '03'):
        return '?ETX?'
    elif(inputHexChar == '04'):
        return '?EOT?'
    elif(inputHexChar == '05'):
        return '?ENQ?'
    elif(inputHexChar == '06'):
        return '?ACK?'
    elif(inputHexChar == '07'):
        return '?BELL?'
    elif(inputHexChar == '08'):
        return '?BS?'
    elif(inputHexChar == '09'):
        return '?TAB?'
    elif(inputHexChar == '0a'):
        return '?LF?'
    elif(inputHexChar == '0b'):
        return '?VT?'
    elif(inputHexChar == '0c'):
        return '?FF?'
    elif(inputHexChar == '0d'):
        return '?CR?'
    elif(inputHexChar == '0e'):
        return '?SO?'
    elif(inputHexChar == '0f'):
        return '?SI?'
    elif(inputHexChar == '10'):
        return '?DLE?'
    elif(inputHexChar == '11'):
        return '?DC1?'
    elif(inputHexChar == '12'):
        return '?DC2?'
    elif(inputHexChar == '13'):
        return '?DC3?'
    elif(inputHexChar == '14'):
        return '?DC4?'
    elif(inputHexChar == '15'):
        return '?NAK?'
    elif(inputHexChar == '16'):
        return '?SYN?'
    elif(inputHexChar == '17'):
        return '?ETB?'
    elif(inputHexChar == '18'):
        return '?CAN?'
    elif(inputHexChar == '19'):
        return '?EM?'
    elif(inputHexChar == '1a'):
        return '?SUB?'
    elif(inputHexChar == '1b'):
        return '?ESC?'
    elif(inputHexChar == '1c'):
        return '?FS?'
    elif(inputHexChar == '1d'):
        return '?GS?'
    elif(inputHexChar == '1e'):
        return '?RS?'
    elif(inputHexChar == '1f'):
        return '?US?'
    elif(inputHexChar == '20'):
        return '?Space?'
    elif(inputHexChar == '21'):
        return '!'
    elif(inputHexChar == '22'):
        return '"'
    elif(inputHexChar == '23'):
        return '#'
    elif(inputHexChar == '24'):
        return '$'
    elif(inputHexChar == '25'):
        return '%'
    elif(inputHexChar == '26'):
        return '&'
    elif(inputHexChar == '27'):
        return "'"
    elif(inputHexChar == '28'):
        return '('
    elif(inputHexChar == '29'):
        return ')'
    elif(inputHexChar == '2a'):
        return '*'
    elif(inputHexChar == '2b'):
        return '+'
    elif(inputHexChar == '2c'):
        return ','
    elif(inputHexChar == '2d'):
        return '-'
    elif(inputHexChar == '2e'):
        return '.'
    elif(inputHexChar == '2f'):
        return '/'
    elif(inputHexChar == '30'):
        return '0'
    elif(inputHexChar == '31'):
        return '1'
    elif(inputHexChar == '32'):
        return '2'
    elif(inputHexChar == '33'):
        return '3'
    elif(inputHexChar == '34'):
        return '4'
    elif(inputHexChar == '35'):
        return '5'
    elif(inputHexChar == '36'):
        return '6'
    elif(inputHexChar == '37'):
        return '7'
    elif(inputHexChar == '38'):
        return '8'
    elif(inputHexChar == '39'):
        return '9'
    elif(inputHexChar == '3a'):
        return ':'
    elif(inputHexChar == '3b'):
        return ';'
    elif(inputHexChar == '3c'):
        return '<'
    elif(inputHexChar == '3d'):
        return '='
    elif(inputHexChar == '3e'):
        return '>'
    elif(inputHexChar == '3f'):
        return '?'
    elif(inputHexChar == '40'):
        return '@'
    elif(inputHexChar == '41'):
        return 'A'
    elif(inputHexChar == '42'):
        return 'B'
    elif(inputHexChar == '43'):
        return 'C'
    elif(inputHexChar == '44'):
        return 'D'
    elif(inputHexChar == '45'):
        return 'E'
    elif(inputHexChar == '46'):
        return 'F'
    elif(inputHexChar == '47'):
        return 'G'
    elif(inputHexChar == '48'):
        return 'H'
    elif(inputHexChar == '49'):
        return 'I'
    elif(inputHexChar == '4a'):
        return 'J'
    elif(inputHexChar == '4b'):
        return 'K'
    elif(inputHexChar == '4c'):
        return 'L'
    elif(inputHexChar == '4d'):
        return 'M'
    elif(inputHexChar == '4e'):
        return 'N'
    elif(inputHexChar == '4f'):
        return 'O'
    elif(inputHexChar == '50'):
        return 'P'
    elif(inputHexChar == '51'):
        return 'Q'
    elif(inputHexChar == '52'):
        return 'R'
    elif(inputHexChar == '53'):
        return 'S'
    elif(inputHexChar == '54'):
        return 'T'
    elif(inputHexChar == '55'):
        return 'U'
    elif(inputHexChar == '56'):
        return 'V'
    elif(inputHexChar == '57'):
        return 'W'
    elif(inputHexChar == '58'):
        return 'X'
    elif(inputHexChar == '59'):
        return 'Y'
    elif(inputHexChar == '5a'):
        return 'Z'
    elif(inputHexChar == '5b'):
        return '['
    elif(inputHexChar == '5c'):
        return '\\'
    elif(inputHexChar == '5d'):
        return ']'
    elif(inputHexChar == '5e'):
        return '^'
    elif(inputHexChar == '5f'):
        return '_'
    elif(inputHexChar == '60'):
        return '`'
    elif(inputHexChar == '61'):
        return 'a'
    elif(inputHexChar == '62'):
        return 'b'
    elif(inputHexChar == '63'):
        return 'c'
    elif(inputHexChar == '64'):
        return 'd'
    elif(inputHexChar == '65'):
        return 'e'
    elif(inputHexChar == '66'):
        return 'f'
    elif(inputHexChar == '67'):
        return 'g'
    elif(inputHexChar == '68'):
        return 'h'
    elif(inputHexChar == '69'):
        return 'i'
    elif(inputHexChar == '6a'):
        return 'j'
    elif(inputHexChar == '6b'):
        return 'k'
    elif(inputHexChar == '6c'):
        return 'l'
    elif(inputHexChar == '6d'):
        return 'm'
    elif(inputHexChar == '6e'):
        return 'n'
    elif(inputHexChar == '6f'):
        return 'o'
    elif(inputHexChar == '70'):
        return 'p'
    elif(inputHexChar == '71'):
        return 'q'
    elif(inputHexChar == '72'):
        return 'r'
    elif(inputHexChar == '73'):
        return 's'
    elif(inputHexChar == '74'):
        return 't'
    elif(inputHexChar == '75'):
        return 'u'
    elif(inputHexChar == '76'):
        return 'v'
    elif(inputHexChar == '77'):
        return 'w'
    elif(inputHexChar == '78'):
        return 'x'
    elif(inputHexChar == '79'):
        return 'y'
    elif(inputHexChar == '7a'):
        return 'z'
    elif(inputHexChar == '7b'):
        return '{'
    elif(inputHexChar == '7c'):
        return '|'
    elif(inputHexChar == '7d'):
        return '}'
    elif(inputHexChar == '7e'):
        return '~'
    elif(inputHexChar == '7f'):
        return 'DE'
    else:
        return '?OVER127?'

#this function takes any-size string of HEX in 2 char form
#outputs a string of chars from the HEX

def hexStrToAscii(inputHex):

    counter = 0
    strReturn = []
    while counter < len(inputHex):
        strReturn = strReturn +  [hexCharToAscii(inputHex[counter] + inputHex[counter + 1])]
        counter = counter + 2

    rtr = str(strReturn)
    
    return rtr

#returns a list of intergers that represent the input hex
def hexStrToAsciiInteger(inputHex):

    counter = 0
    returnInts = []
    while counter < len(inputHex):
        returnInts.append(hexCharOrd(inputHex[counter] + inputHex[counter + 1]))
        counter = counter + 2

    return returnInts

#right now this function only uses lower case for hex letters
#returns integer representation of ASCII HEX(01, 7f, etc..) value
def hexCharOrd(inputHexChar):
    
    if(inputHexChar == '00'):
        return 0
    elif(inputHexChar == '01'):
        return 1
    elif(inputHexChar == '02'):
        return 2
    elif(inputHexChar == '03'):
        return 3
    elif(inputHexChar == '04'):
        return 4
    elif(inputHexChar == '05'):
        return 5
    elif(inputHexChar == '06'):
        return 6
    elif(inputHexChar == '07'):
        return 7
    elif(inputHexChar == '08'):
        return 8
    elif(inputHexChar == '09'):
        return 9
    elif(inputHexChar == '0a'):
        return 10
    elif(inputHexChar == '0b'):
        return 11
    elif(inputHexChar == '0c'):
        return 12
    elif(inputHexChar == '0d'):
        return 13
    elif(inputHexChar == '0e'):
        return 14
    elif(inputHexChar == '0f'):
        return 15
    elif(inputHexChar == '10'):
        return 16
    elif(inputHexChar == '11'):
        return 17
    elif(inputHexChar == '12'):
        return 18
    elif(inputHexChar == '13'):
        return 19
    elif(inputHexChar == '14'):
        return 20
    elif(inputHexChar == '15'):
        return 21
    elif(inputHexChar == '16'):
        return 22
    elif(inputHexChar == '17'):
        return 23
    elif(inputHexChar == '18'):
        return 24
    elif(inputHexChar == '19'):
        return 25
    elif(inputHexChar == '1a'):
        return 26
    elif(inputHexChar == '1b'):
        return 27
    elif(inputHexChar == '1c'):
        return 28
    elif(inputHexChar == '1d'):
        return 29
    elif(inputHexChar == '1e'):
        return 30
    elif(inputHexChar == '1f'):
        return 31
    elif(inputHexChar == '20'):
        return 32
    elif(inputHexChar == '21'):
        return 33
    elif(inputHexChar == '22'):
        return 34
    elif(inputHexChar == '23'):
        return 35
    elif(inputHexChar == '24'):
        return 36
    elif(inputHexChar == '25'):
        return 37
    elif(inputHexChar == '26'):
        return 38
    elif(inputHexChar == '27'):
        return 39
    elif(inputHexChar == '28'):
        return 40
    elif(inputHexChar == '29'):
        return 41
    elif(inputHexChar == '2a'):
        return 42
    elif(inputHexChar == '2b'):
        return 43
    elif(inputHexChar == '2c'):
        return 44
    elif(inputHexChar == '2d'):
        return 45
    elif(inputHexChar == '2e'):
        return 46
    elif(inputHexChar == '2f'):
        return 47
    elif(inputHexChar == '30'):
        return 48
    elif(inputHexChar == '31'):
        return 49
    elif(inputHexChar == '32'):
        return 50
    elif(inputHexChar == '33'):
        return 51
    elif(inputHexChar == '34'):
        return 52
    elif(inputHexChar == '35'):
        return 53
    elif(inputHexChar == '36'):
        return 54
    elif(inputHexChar == '37'):
        return 55
    elif(inputHexChar == '38'):
        return 56
    elif(inputHexChar == '39'):
        return 57
    elif(inputHexChar == '3a'):
        return 58
    elif(inputHexChar == '3b'):
        return 59
    elif(inputHexChar == '3c'):
        return 60
    elif(inputHexChar == '3d'):
        return 61
    elif(inputHexChar == '3e'):
        return 62
    elif(inputHexChar == '3f'):
        return 63
    elif(inputHexChar == '40'):
        return 64
    elif(inputHexChar == '41'):
        return 65
    elif(inputHexChar == '42'):
        return 66
    elif(inputHexChar == '43'):
        return 67
    elif(inputHexChar == '44'):
        return 68
    elif(inputHexChar == '45'):
        return 69
    elif(inputHexChar == '46'):
        return 70
    elif(inputHexChar == '47'):
        return 71
    elif(inputHexChar == '48'):
        return 72
    elif(inputHexChar == '49'):
        return 73
    elif(inputHexChar == '4a'):
        return 74
    elif(inputHexChar == '4b'):
        return 75
    elif(inputHexChar == '4c'):
        return 76
    elif(inputHexChar == '4d'):
        return 77
    elif(inputHexChar == '4e'):
        return 78
    elif(inputHexChar == '4f'):
        return 79
    elif(inputHexChar == '50'):
        return 80
    elif(inputHexChar == '51'):
        return 81
    elif(inputHexChar == '52'):
        return 82
    elif(inputHexChar == '53'):
        return 83
    elif(inputHexChar == '54'):
        return 84
    elif(inputHexChar == '55'):
        return 85
    elif(inputHexChar == '56'):
        return 86
    elif(inputHexChar == '57'):
        return 87
    elif(inputHexChar == '58'):
        return 88
    elif(inputHexChar == '59'):
        return 89
    elif(inputHexChar == '5a'):
        return 90
    elif(inputHexChar == '5b'):
        return 91
    elif(inputHexChar == '5c'):
        return 92
    elif(inputHexChar == '5d'):
        return 93
    elif(inputHexChar == '5e'):
        return 94
    elif(inputHexChar == '5f'):
        return 95
    elif(inputHexChar == '60'):
        return 96
    elif(inputHexChar == '61'):
        return 97
    elif(inputHexChar == '62'):
        return 98
    elif(inputHexChar == '63'):
        return 99
    elif(inputHexChar == '64'):
        return 100
    elif(inputHexChar == '65'):
        return 101
    elif(inputHexChar == '66'):
        return 102
    elif(inputHexChar == '67'):
        return 103
    elif(inputHexChar == '68'):
        return 104
    elif(inputHexChar == '69'):
        return 105
    elif(inputHexChar == '6a'):
        return 106
    elif(inputHexChar == '6b'):
        return 107
    elif(inputHexChar == '6c'):
        return 108
    elif(inputHexChar == '6d'):
        return 109
    elif(inputHexChar == '6e'):
        return 110
    elif(inputHexChar == '6f'):
        return 111
    elif(inputHexChar == '70'):
        return 112
    elif(inputHexChar == '71'):
        return 113
    elif(inputHexChar == '72'):
        return 114
    elif(inputHexChar == '73'):
        return 115
    elif(inputHexChar == '74'):
        return 116
    elif(inputHexChar == '75'):
        return 117
    elif(inputHexChar == '76'):
        return 118
    elif(inputHexChar == '77'):
        return 119
    elif(inputHexChar == '78'):
        return 120
    elif(inputHexChar == '79'):
        return 121
    elif(inputHexChar == '7a'):
        return 122
    elif(inputHexChar == '7b'):
        return 123
    elif(inputHexChar == '7c'):
        return 124
    elif(inputHexChar == '7d'):
        return 125
    elif(inputHexChar == '7e'):
        return 126
    elif(inputHexChar == '7f'):
        return 127
    elif(inputHexChar == '80'):
        return 128
    elif(inputHexChar == '81'):
       return 129
    elif(inputHexChar == '82'):
       return 130
    elif(inputHexChar == '83'):
       return 131
    elif(inputHexChar == '84'):
       return 132
    elif(inputHexChar == '85'):
       return 133
    elif(inputHexChar == '86'):
       return 134
    elif(inputHexChar == '87'):
       return 135
    elif(inputHexChar == '88'):
       return 136
    elif(inputHexChar == '89'):
       return 137
    elif(inputHexChar == '8a'):
       return 138
    elif(inputHexChar == '8b'):
       return 139
    elif(inputHexChar == '8c'):
       return 140
    elif(inputHexChar == '8d'):
       return 141
    elif(inputHexChar == '8e'):
       return 142
    elif(inputHexChar == '8f'):
       return 143
    elif(inputHexChar == '90'):
       return 144
    elif(inputHexChar == '91'):
       return 145
    elif(inputHexChar == '92'):
       return 146
    elif(inputHexChar == '93'):
       return 147
    elif(inputHexChar == '94'):
       return 148
    elif(inputHexChar == '95'):
       return 149
    elif(inputHexChar == '96'):
       return 150
    elif(inputHexChar == '97'):
       return 151
    elif(inputHexChar == '98'):
       return 152
    elif(inputHexChar == '99'):
       return 153
    elif(inputHexChar == '9a'):
       return 154
    elif(inputHexChar == '9b'):
       return 155
    elif(inputHexChar == '9c'):
       return 156
    elif(inputHexChar == '9d'):
       return 157
    elif(inputHexChar == '9e'):
       return 158
    elif(inputHexChar == '9f'):
       return 159
    elif(inputHexChar == 'a0'):
       return 160
    elif(inputHexChar == 'a1'):
       return 161
    elif(inputHexChar == 'a2'):
       return 162
    elif(inputHexChar == 'a3'):
       return 163
    elif(inputHexChar == 'a4'):
       return 164
    elif(inputHexChar == 'a5'):
       return 165
    elif(inputHexChar == 'a6'):
       return 166
    elif(inputHexChar == 'a7'):
       return 167
    elif(inputHexChar == 'a8'):
       return 168
    elif(inputHexChar == 'a9'):
       return 169
    elif(inputHexChar == 'aa'):
       return 170
    elif(inputHexChar == 'ab'):
       return 171
    elif(inputHexChar == 'ac'):
       return 172
    elif(inputHexChar == 'ad'):
       return 173
    elif(inputHexChar == 'ae'):
       return 174
    elif(inputHexChar == 'af'):
       return 175
    elif(inputHexChar == 'b0'):
       return 176
    elif(inputHexChar == 'b1'):
       return 177
    elif(inputHexChar == 'b2'):
       return 178
    elif(inputHexChar == 'b3'):
       return 179
    elif(inputHexChar == 'b4'):
       return 180
    elif(inputHexChar == 'b5'):
       return 181
    elif(inputHexChar == 'b6'):
       return 182
    elif(inputHexChar == 'b7'):
       return 183
    elif(inputHexChar == 'b8'):
       return 184
    elif(inputHexChar == 'b9'):
       return 185
    elif(inputHexChar == 'ba'):
       return 186
    elif(inputHexChar == 'bb'):
       return 187
    elif(inputHexChar == 'bc'):
       return 188
    elif(inputHexChar == 'bd'):
       return 189
    elif(inputHexChar == 'be'):
       return 190
    elif(inputHexChar == 'bf'):
       return 191
    elif(inputHexChar == 'c0'):
       return 192
    elif(inputHexChar == 'c1'):
       return 193
    elif(inputHexChar == 'c2'):
       return 194
    elif(inputHexChar == 'c3'):
       return 195
    elif(inputHexChar == 'c4'):
       return 196
    elif(inputHexChar == 'c5'):
       return 197
    elif(inputHexChar == 'c6'):
       return 198
    elif(inputHexChar == 'c7'):
       return 199
    elif(inputHexChar == 'c8'):
       return 200
    elif(inputHexChar == 'c9'):
       return 201
    elif(inputHexChar == 'ca'):
       return 202
    elif(inputHexChar == 'cb'):
       return 203
    elif(inputHexChar == 'cc'):
       return 204
    elif(inputHexChar == 'cd'):
       return 205
    elif(inputHexChar == 'ce'):
       return 206
    elif(inputHexChar == 'cf'):
       return 207
    elif(inputHexChar == 'd0'):
       return 208
    elif(inputHexChar == 'd1'):
       return 209
    elif(inputHexChar == 'd2'):
       return 210
    elif(inputHexChar == 'd3'):
       return 211
    elif(inputHexChar == 'd4'):
       return 212
    elif(inputHexChar == 'd5'):
       return 213
    elif(inputHexChar == 'd6'):
       return 214
    elif(inputHexChar == 'd7'):
       return 215
    elif(inputHexChar == 'd8'):
       return 216
    elif(inputHexChar == 'd9'):
       return 217
    elif(inputHexChar == 'da'):
       return 218
    elif(inputHexChar == 'db'):
       return 219
    elif(inputHexChar == 'dc'):
       return 220
    elif(inputHexChar == 'dd'):
       return 221
    elif(inputHexChar == 'de'):
       return 222
    elif(inputHexChar == 'df'):
       return 223
    elif(inputHexChar == 'e0'):
       return 224
    elif(inputHexChar == 'e1'):
       return 225
    elif(inputHexChar == 'e2'):
       return 226
    elif(inputHexChar == 'e3'):
       return 227
    elif(inputHexChar == 'e4'):
       return 228
    elif(inputHexChar == 'e5'):
       return 229
    elif(inputHexChar == 'e6'):
       return 230
    elif(inputHexChar == 'e7'):
       return 231
    elif(inputHexChar == 'e8'):
       return 232
    elif(inputHexChar == 'e9'):
       return 233
    elif(inputHexChar == 'ea'):
       return 234
    elif(inputHexChar == 'eb'):
       return 235
    elif(inputHexChar == 'ec'):
       return 236
    elif(inputHexChar == 'ed'):
       return 237
    elif(inputHexChar == 'ee'):
       return 238
    elif(inputHexChar == 'ef'):
       return 239
    elif(inputHexChar == 'f0'):
       return 240
    elif(inputHexChar == 'f1'):
       return 241
    elif(inputHexChar == 'f2'):
       return 242
    elif(inputHexChar == 'f3'):
       return 243
    elif(inputHexChar == 'f4'):
       return 244
    elif(inputHexChar == 'f5'):
       return 245
    elif(inputHexChar == 'f6'):
       return 246
    elif(inputHexChar == 'f7'):
       return 247
    elif(inputHexChar == 'f8'):
       return 248
    elif(inputHexChar == 'f9'):
       return 249
    elif(inputHexChar == 'fa'):
       return 250
    elif(inputHexChar == 'fb'):
       return 251
    elif(inputHexChar == 'fc'):
       return 252
    elif(inputHexChar == 'fd'):
       return 253
    elif(inputHexChar == 'fe'):
       return 254
    elif(inputHexChar == 'ff'):
       return 255

def xorAndDispay(f1, f2):
    file1 = hexStrToAsciiInteger(f1)
    file2 = hexStrToAsciiInteger(f2)
    
    if(len(file1) > len(file2)):
       outString = "".join([chr(x ^ y) for (x, y) in zip(file1[:len(file2)], file2)])
       currentFile = outString
       print(outString)
       input('Press any key....')
    else:
        outString = "".join([chr(x ^ y) for (x, y) in zip(file1, file2[:len(file1)])])
        currentFile = outString
        print(outString)
        input('Press any key....')

def compare_two_files():
    fileOne = input('Enter file#1: Files 0-10 -->')
    fileTwo = input('Enter file#2: Files 0-10 -->')
    xorAndDispay(fileList[int(fileOne)], fileList[int(fileTwo)])

def unprintable_char(c):
    if(c == 0):
        return '?NULL?'
    elif(c == 1):
        return '?SOH?'
    elif(c == 2):
        return '?STX?'
    elif(c == 3):
        return '?ETX?'
    elif(c == 4):
        return '?EOT?'
    elif(c == 5):
        return '?ENQ?'
    elif(c == 6):
        return '?ACK?'
    elif(c == 7):
        return '?BELL?'
    elif(c == 8):
        return '?BS?'
    elif(c == 9):
        return '?TAB?'
    elif(c == 10):
        return '?LF?'
    elif(c == 11):
        return '?VT?'
    elif(c == 12):
        return '?FF?'
    elif(c == 13):
        return '?CR?'
    elif(c == 14):
        return '?SO?'
    elif(c == 15):
        return '?SI?'
    elif(c == 16):
        return '?DLE?'
    elif(c == 17):
        return '?DC1?'
    elif(c == 18):
        return '?DC2?'
    elif(c == 19):
        return '?DC3?'
    elif(c == 20):
        return '?DC4?'
    elif(c == 21):
        return '?NAK?'
    elif(c == 22):
        return '?SYN?'
    elif(c == 23):
        return '?ETB?'
    elif(c == 24):
        return '?CAN?'
    elif(c == 25):
        return '?EM?'
    elif(c == 26):
        return '?SUB?'
    elif(c == 27):
        return '?ESC?'
    elif(c == 28):
        return '?FS?'
    elif(c == 29):
        return '?GS?'
    elif(c == 30):
        return '?RS?'
    elif(c == 31):
        return '?US?'
    elif(c == 32):
        return '?Space?'
    elif(c > 127):
        return '?OVER127?'

def build_hash_list():
    counter1 = 0
    counter2 = 0
    global hashList

    while(counter1 < 256):
        
        while(counter2 < 256):

            index = counter1 ^ counter2
            char1 = ''
            char2 = ''

            if(counter1 < 33 or counter1 > 127):
                char1 = unprintable_char(counter1)
            else:
                char1 = chr(counter1)
            if(counter2 < 33 or counter2 > 127):
                char2 = unprintable_char(counter2)
            else:
                char2 = chr(counter2)

            hashList[index].append(char1 + char2)
           
            # print('Character1 = ')
            #print(char1)
            # print('Character2 = ')
            # print(char2)
            counter2 = counter2 + 1

        counter2 = 0
        counter1 = counter1 + 1



def analyze_and_display(f1, f2):
    file1 = hexStrToAsciiInteger(f1)
    file2 = hexStrToAsciiInteger(f2)
    x = 0
    hashValue = 0

    if(len(file1) > len(file2)):
        x = len(file2)
    else:
        x = len(file1)

    for index in range(x):
        hashValue = file1[index] ^ file2[index]
        print('Possible values for')
        print(index + 1)
        print('position are:')
        
        for chars in hashList[hashValue]:
            print(chars)

        input('Press enter')
         

    

def analyze_two_files():
    file1 = input('Enter file#1: Files 0-10 -->')
    file2 = input('Enter file#2: Files 0-10 -->')
    analyze_and_display(fileList[int(file1)], fileList[int(file2)])

for subdir, dirs, files in os.walk(myPytonFilesDir):
    for file in files:
        openFile = myPytonFilesDir + '\\' + file
        with open(openFile) as inputFile:
            #print('adding file')
            fileList = fileList + [inputFile.read()]
        inputFile.close()

#build hash list here of all possible combinations of XORs
print('Building hash table.  Please wait.....')
build_hash_list()

print('Welcome to Crypto Home Work #1 \n')
print('Please choose an option')
print('1 to XOR two files output to screen')
print('2 to XOR and analyze two files. Output possible matches to screen')
print('3 to analyze file and output best matches.')
print('5 to exit')
option = input('-->')

while(option != '5'):
    if(option == '1'):
        compare_two_files()
    if(option == '2'):
        analyze_two_files()

    print('Welcome to Crypto Home Work #1 \n')
    print('Please choose an option')
    print('1 to XOR compare two files')
    print('2 to XOR and analyze two files. Output possible matches to screen')
    print('3 to analyze file and output best matches.')
    print('5 to exit')
    option = input('-->')
   

#for file in fileList:
    #asciiOut = hexStrToAscii(file)
    #print(asciiOut)
    #intOut = hexStrToAsciiInteger(file)
    #for int in intOut:
        #print(int)



#//////////////////////////////////////////////////////////////////////////////////////////////////////////////
#with open('C:\TempNew\Python\Crypto\HW1\ct1.txt') as inputFile:
#    print(inputFile.read())

#inputFile.close()

#//////////////////////////////////////////////////////////////////////////////////////////////////
#EOF

