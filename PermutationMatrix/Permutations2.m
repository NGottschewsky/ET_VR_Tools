% https://de.mathworks.com/matlabcentral/answers/360555-pseudorandom-sequence-without-consecutively-repeating-numbers

nconditions = 24;
nrepeats = 5;
nparticipants = 20;

n = nconditions * nrepeats;
result = zeros(nparticipants,n);
for i = 1 : nparticipants
    result(i,1:nconditions) = randperm(nconditions);
    disp('Test Values: ')
    n;
    result;
    for k = 1:nrepeats-1
        m= k * nconditions;
        r = randperm(nconditions);
        
        if(r(i) == result(i,m))
            r = fliplr(r);
        end
        
        result(i,m+1:m+nconditions) = r;
    end

end

result