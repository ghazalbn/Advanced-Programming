import re

name = input("Enter file:")
if len(name) < 1 : name = "regex_sum_414403.txt"
handle = open(name)
print(sum([int(line) for line in re.findall('[0-9]+', handle.read())]))
