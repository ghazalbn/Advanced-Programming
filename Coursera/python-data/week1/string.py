text = "X-DSPAM-Confidence:    0.8475"
print(float(text[text.find('0'):text.find('0')+7]))