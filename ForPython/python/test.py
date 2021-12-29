from customModul import help
from customModul import sifrelemeYontemleri
from customModul import dilKontrol

help = help()

print("\n\nFonksiyonlar Kullanım Örnekleri\n\n")

a = sifrelemeYontemleri()
print("SHA256 Hash kullanımı: ", a.hash256("sude"))
print("MD5 Hash kullanımı: ", a.hashMd5("karanlık"))
print("SHA224 Hash kullanımı: ", a.hash224("ev"))
print("SHA512 Hash kullanımı: ", a.hash512("mor"))
print("SHA512 Hash kullanımı: ", a.hash1("mor"))

print()
print()

message = "Selam, benim adım Efe. Seninki ne? Bir de sana bir sorum var: Hey, sana diyorum!"
b = dilKontrol(message)

print("splitByWords: ", b.splitByWords())
print("wordCounter: ", b.wordCounter())
print("splitBySentence: ", b.splitBySentence())
print("sentenceCounter: ", b.sentenceCounter())
print("vowelChars: ", b.vowelChars())
print("vowelCounter: ", b.vowelCounter())
print("buyuk unluye uyan / uymayan kelimelerin sayisi: ", b.buyukUnluUyumu())