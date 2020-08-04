% the 12 Tools, always 2 numbers per tool, first number left oriented and
% 2nd number right oriented, --> 1 = Hammer with effector left, 2 = Hammer
% with effector right
tools = 1:24;

condition = [0 1];

% vector of 120 elements where every tool appears exactly 10 times
u = repelem(tools,5);

% vector of 60 elements (60 trials per block) where every condition appears
% 30 times
v = repelem(condition, 30);

% make empty matrix of 20 rows (for 20 participants) and 120 columns (for 120
% trials)
ExpMatrix = zeros(20,120);

% make empty matrix of 20 rows and 120 columns 
Condition = zeros(20,120);

% fill matrix so that every tool appears 10 times per row in a random order
% Problem: Sometimes same number appears twice in a row --> Solved below
for i = 1:20
    % randsample samples without replacement, so that every tools appears
    % exactly 10 times
    ExpMatrix(i,:) = randsample(u,120);
    Condition(i,1:60) = randsample(v,60);
    Condition(i,61:120) = randsample(v,60);
end

for x = 1 : 20
    
    for y = 1 : 119
        
        if(ExpMatrix(x,y) == ExpMatrix(x,y+1))
            temp = ExpMatrix(x,y);
            random = randi(120);
            
            switch y
                
                case 1
                    
                    switch random
                        
                        case 1
                            
                            random = randi(120);
                            
                        case 120
                            
                            while((ExpMatrix(x,random)==ExpMatrix(x,y)) || (ExpMatrix(x,y)==ExpMatrix(x,random-1)))
                                random = randi(120);
                            end    
                            
                        otherwise
                        
                            while((ExpMatrix(x,random)==ExpMatrix(x,y)) || (ExpMatrix(x,y)==ExpMatrix(x,random+1)) || (ExpMatrix(x,y)==ExpMatrix(x,random-1)))
                                random = randi(120);
                            end
                        
                    end
                    
                case 120
                    
                    switch random
                        
                        case 1
    
                            while((ExpMatrix(x,random)==ExpMatrix(x,y)) || (ExpMatrix(x,random)==ExpMatrix(x,y-1)) || (ExpMatrix(x,y)==ExpMatrix(x,random+1)))
                                random = randi(120);
                            end
                          
                        case 120
                            
                            random = randi(120)
                            
                        otherwise
                            
                            while((ExpMatrix(x,random)==ExpMatrix(x,y)) || (ExpMatrix(x,random)==ExpMatrix(x,y-1)) || (ExpMatrix(x,y)==ExpMatrix(x,random+1)) || (ExpMatrix(x,y)==ExpMatrix(x,random-1)))
                                random = randi(120);
                            end
                          
                    end 
                    
                otherwise
                    
                    switch random
                        
                        case 1
                            
                            while((ExpMatrix(x,random)==ExpMatrix(x,y)) || (ExpMatrix(x,random)==ExpMatrix(x,y-1)) || (ExpMatrix(x,y)==ExpMatrix(x,random+1)))
                                random = randi(120);
                            end
                            
                        case 120
                            
                            while((ExpMatrix(x,random)==ExpMatrix(x,y)) || (ExpMatrix(x,random)==ExpMatrix(x,y-1)) || (ExpMatrix(x,y)==ExpMatrix(x,random-1)))
                                random = randi(120);
                            end
                            
                        otherwise
                            
                            while((ExpMatrix(x,random)==ExpMatrix(x,y)) || (ExpMatrix(x,random)==ExpMatrix(x,y-1)) || (ExpMatrix(x,y)==ExpMatrix(x,random+1)) || (ExpMatrix(x,y)==ExpMatrix(x,random-1)))
                                random = randi([2,119]);
                            end
                    end
            end
            
             ExpMatrix(x,y) = ExpMatrix(x,random);
             ExpMatrix(x,random) = temp;
             
        end
    end
end

for x = 1 : 20
    
    for y = 1 : 119
        
        if(ExpMatrix(x,y) == ExpMatrix(x,y+1))
            disp('Doppelter Wert: Reihe ' + x + 'Spalte' + y)
        end
        
    end
end

%csvwrite('ExperimentLoopMatrix.csv',ExpMatrix)
%csvwrite('ConditionMatrix.csv',Condition)