name = input("Enter file:")
if len(name) < 1 : name = "mbox-short.txt"
handle = open(name)
emails = {}
for line in handle:
    if line.startswith("From "):
        emails[line.split()[1]] = emails.get(line.split()[1], 0) + 1
big_count = 0
big_email = None
for email, count in emails.items():
    if count > big_count:
        big_count = count
        big_email = email
print(big_email, big_count)