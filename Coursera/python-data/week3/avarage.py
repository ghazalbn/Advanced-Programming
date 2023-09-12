# Use the file name mbox-short.txt as the file name
fname = input("Enter file name: ")
fh = open(fname)
s = 0
count = 0
for line in fh:
    if not line.startswith("X-DSPAM-Confidence:") : continue
    s += float(line[20:])
    count += 1
print('Average spam confidence:', s/count)