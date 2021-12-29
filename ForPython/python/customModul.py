import base64
import hashlib
from Cryptodome.Cipher import AES
from Cryptodome.Random import get_random_bytes
class sifrelemeYontemleri:
    def __init__(self):
        pass

    #init olacak
    def hash256(self, plainText):
        hashed_string = hashlib.sha256(plainText.encode('utf-8')).hexdigest()
        return hashed_string

    def hashMd5(self, plainText):
        hashed_string = hashlib.md5(plainText.encode('utf-8')).hexdigest()
        return hashed_string

    def hash224(self, plainText):
        hashed_string = hashlib.sha224(plainText.encode('utf-8')).hexdigest()
        return hashed_string

    def hash512(self, plainText):
        hashed_string = hashlib.sha512(plainText.encode('utf-8')).hexdigest()
        return hashed_string

    def hash1(self, plainText):
        hashed_string = hashlib.sha1(plainText.encode('utf-8')).hexdigest()
        return hashed_string

    
    # def encrypt(msg):
    #     key = token_bytes(16)
    #     cipher = AES.new(key,AES.MODE_EAX)
    #     nonce = cipher.nonce
    #     cipherText, tag = cipher.encrypt_and_digest(msg.encode('ascii'))
    #     return nonce, cipherText,tag

    # def decrypt(nonce, cipherText, tag):
    #     key = token_bytes(16)
    #     cipher = AES.new(key,AES.MODE_EAX, nonce=nonce)
    #     plaintext = cipher.decrypt(cipherText)
    #     try:
    #         cipher.verify(tag)
    #         return plaintext.decode('ascii')
    #     except:
    #         return False

    # nonce, cipherText, tag = encrypt(input("Mesajınızı giriniz: "))
    # plainText = decrypt(nonce, cipherText, tag)
    # print(f'CipherText: {cipherText}')
    # if not plainText:
    #     print("mesaj bozuk")
    # else:
    #     print(f'Plaintext: {plainText}')    

class dilKontrol:

    def __init__(self, text):
        try: # Gelen mesaj stringse direkt alıyoruz, değilse stringe çevirerek alıyoruz. 
            text.split(' ') 
            self.text = text
        except:
            self.text = str(text)

    def wordCounter(self):# Parametre olarak sayılacak kelime listesini alır. Listenin eleman sayısını döndürür.
        return len(self.splitByWords())

    def splitByWords(self):# Kelimelere ayırır ve kelime listesini döndürür.
        message = self.text
        message = message.split(' ')
        return message

    def sentenceCounter(self):# Parametre olarak sayılacak cümle listesini alır. Listenin eleman sayısını döndürür.
        return len(self.splitBySentence())    

    def splitBySentence(self):# Cümlelere ayırır ve cümle listesini döndürür.
        message = self.text
        marks="?:!"
        for i in marks: # Noktalama işaretlerinin tümünü "." karakterine çevirir.
            message = message.replace(i, ".")
        message = message.split('.')
        
        for i in range(len(message)):
            message[i] = message[i].strip() # Cümlenin başındaki ve sonundaki boşlukları siler
        return list(filter(lambda x: len(x)>0,message)) # Listede karakter bulunuyorsa bunu bir cümle olarak sayar ve döndürür 

    def vowelCounter(self):#Sesli harf sayısını döndürür
        return len(self.vowelChars())

    def vowelChars(self,message=None): # Sesli harf listesini döndürür.
        if message == None:
            message = self.text

        vowels = "aeıioöuü"
        vowelsInTheWord = []
        for i in message:
            if i.lower() in vowels:
                vowelsInTheWord.append(i)
        return vowelsInTheWord

    def buyukUnluUyumu(self): # Cümlenin kelimelerinin büyük ünlü uyumuna uygunluğunu kontrol eder, uyan ve uymayan kelime sayısını döndürür
        words = self.splitByWords() # Cümledeki kelime listesini alır
        thinVowels = "eiöü" # İnce sesliler
        legalWords = 0 # Büyük ünlü uyumuna uyan kelimelerin sayacı
        for i in range(len(words)):
            wordVowels = self.vowelChars(words[i].lower()) # Kelimenin sesli harflerini al
            x = 1
            while x < len(wordVowels):
                if wordVowels[0] in thinVowels:
                    if wordVowels[x] not in thinVowels:
                        break
                    x = x + 1
                else:
                    if wordVowels[x] in thinVowels:
                        break
                    x = x + 1

            if x == len(wordVowels): # While döngüsünün kırılmadan tamamlandığını gösterir. Bu durumda kelimenin bütün seslileri incedir.
                legalWords = legalWords + 1

        illegalWords = len(words) - legalWords
        return (legalWords, illegalWords)


class help:
    def __init__(self):
        print("\nBu modülü kullanarak sifrelemeYontemleri ve dilKontrol sınıflarına erişebiliriz. Sınıflardaki metotlar şunlardır:\n")
        self.ekranaYazdirSifrelemeYontemleri()
        print()
        self.ekranaYazdirDilDogrula()

    def ekranaYazdirSifrelemeYontemleri(self):
        print("sifrelemeYontemleri Class'ı")
        print("------")
        print("hash256 :sha256 algoritması ile hashleme\nhashMd5 : md5 algoritması ile hashleme\nhash224 : sha224 algoritması ile hashleme\nhash512 : sha512 ile hashleme\nhash1 :sha1 algoritması ile hashleme\nencyprtAes : aes ile şifreleme\ndecyrptAes : aes ile decyrpt\nencryptRsa : rsa ile encrypt\ndecyrptRsa : rsa ile decrypt\n")
    
    def ekranaYazdirDilDogrula(self):
        print("dilKontrol Class'ı")
        print("------")
        print("splitByWords: Kelimelere ayırır ve kelime listesini döndürür.\nwordCounter : Parametre olarak sayılacak kelime listesini alır. Listenin eleman sayısını döndürür.\nsplitBySentence : Cümlelere ayırır ve cümle listesini döndürür.\nsentenceCounter : Parametre olarak sayılacak cümle listesini alır. Listenin eleman sayısını döndürür.\nvowelCounter : Sesli harf sayısını döndür.\nvowelChars : Sesli harf listesini döndürür.\nwowelCounter: Sesli harf sayısını döndürür.\nbuyukUnluUyumu : Cümlenin kelimelerinin büyük ünlü uyumuna uygunluğunu kontrol eder, uyan ve uymayan kelime sayısını döndürür.")
