name = input("Enter file:")
if len(name) < 1 : name = "mbox-short.txt"
handle = open(name)
dict = {}
for line in handle:
    if line.startswith("From "):
        hour = line.split()[5].split(':')[0]
        dict[hour] = dict.get(hour, 0) + 1
for hour, count in sorted(dict.items()):
    print(hour, count)